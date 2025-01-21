using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionDialogue : MonoBehaviour
{


    [Header("Interaction")]
    [SerializeField] private Interaction player;
    public Collectable collectable;
    [Header("InkJSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField]private bool isInteracting;

    [SerializeField]public bool gotCollected = false;
    private bool isCollidingWithPlayer;
    private bool hasInteracted;
    private bool isRunningDialogueWithMission = false;
    public GameObject VisualDialogue;

    // Start is called before the first frame update
    void Start()
    {
        gotCollected = false;
        isInteracting = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().isInteracting;
    }

    // Update is called once per frame
    void Update()
    {
        
       isInteracting = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>().isInteracting;
        //Debug.Log("hasInteracted" + hasInteracted);
        if(collectable != null){
        gotCollected = collectable.hasCollected;
        }else{
        gotCollected = false;    
        }
        
       // Debug.Log("HasDetected"+player.hasDetected);
        if (!player.hasDetected && isCollidingWithPlayer)
        {
            //Debug.Log("Diálogo1");
            if (isInteracting || gotCollected || gameObject.tag == "MissionDialogue" && !isRunningDialogueWithMission)
            {
                //Debug.Log("Diálogo2");
                DialogueManager.instance.EnterDialogueMode(inkJSON);
                VisualDialogue.SetActive(false);
                hasInteracted = true;
                isRunningDialogueWithMission = true;
            }
            else
            {
                VisualDialogue.SetActive(true);
                
            }
        }
        
        if(hasInteracted){
            VisualDialogue.SetActive(false);
            
        }

       
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            //Debug.Log("PLAYER DETECTED FOR REAL");
            isCollidingWithPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            isCollidingWithPlayer = false;
            isRunningDialogueWithMission = false;
        }
    }
    
    
}


