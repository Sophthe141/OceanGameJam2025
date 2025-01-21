using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject shadowOverlay;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerNameText;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject[] dialogueChoices;
    [SerializeField] private TextMeshProUGUI[] dialogueChoicesText;
    [Header("Portrait UI")]
    [SerializeField] private Animator portraitAnimator;
    private const string SPEAKER = "speaker";
    private const string PORTRAIT = "portrait";
    private const string LYOUT_TAG = "layout";

    private Story currentStory;
    private Animator layoutAnimator;
    public bool nextDialogueButtonPressed { get; private set; }
    public bool dialogueIsPlaying { get; private set; }
    public static DialogueManager instance;

    [SerializeField] private float textDelaySpeed = 0.01f; // Velocidade de exibição letra por letra
    private Coroutine typingCoroutine;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one DialogueManager in scene");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        dialogueChoicesText = new TextMeshProUGUI[dialogueChoices.Length];
        int index = 0;
        foreach (GameObject choice in dialogueChoices)
        {
            dialogueChoicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        layoutAnimator = dialoguePanel.GetComponent<Animator>();
        dialogueIsPlaying = false;
        nextDialogueButtonPressed = false;
        dialoguePanel.SetActive(false);
        shadowOverlay.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (inputManager.isNextDialogue || nextDialogueButtonPressed)
        {
            if (typingCoroutine != null) // Para exibir todo o texto caso a animação esteja em andamento
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = currentStory.currentText;
                typingCoroutine = null;
            }
            else
            {
                ContinueStory();
            }
            nextDialogueButtonPressed = false;
            inputManager.isNextDialogue = false;
        }
    }

    public void nextDialogueButtonPressedChecker()
    {
        nextDialogueButtonPressed = true;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        if (dialogueIsPlaying)
        {
            return;
        }
        speakerNameText.text = "???";
        portraitAnimator.Play("Default");
        layoutAnimator.Play("left");
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        shadowOverlay.SetActive(true);
        ContinueStory();
    }

    public void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        shadowOverlay.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeLine(currentStory.Continue()));
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags){
        foreach(string tag in currentTags){
            string[] tagSplit = tag.Split(':');
            if(tagSplit.Length != 2){
               Debug.Log("Falhou ao dividir a TAG");
               Debug.Log("Tag em questão:"+tag);
            }
            string tagKey = tagSplit[0].Trim();
            string tagValue = tagSplit[1].Trim();
            switch(tagKey){
                case SPEAKER:
                    speakerNameText.text = tagValue;
                    break;
                case PORTRAIT:
                    portraitAnimator.Play(tagValue);
                    break;
                case LYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.Log("Tag desconhecida: " + tagKey);
                    break;
            }
        }
    }

    private void DisplayChoices(){
        List <Choice> currentChoices = currentStory.currentChoices;
        if(currentChoices.Count > dialogueChoices.Length){
            Debug.LogError("Número de escolhas excede o número de botões de escolha quantidade não suportada = " + currentChoices.Count);
        }
        int index = 0;
        foreach(Choice choice in currentChoices){
            dialogueChoices[index].SetActive(true);
            dialogueChoicesText[index].text = choice.text;
            index++;
        }
        for(int i = index; i < dialogueChoices.Length; i++){
            dialogueChoices[i].SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice(){
        //O Event System da Unity precisa ser limpo primeiro, por algum motivo, aí depois nós colocamos o primeiro botão de escolha
        //Isso é feito um frame antes de poder fazer a escolha
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(dialogueChoices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex){
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        foreach (char c in line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textDelaySpeed);
        }
        typingCoroutine = null; // Resetar para permitir pular para o próximo diálogo
    }

    

}
