using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private bool isIntro = false;
    public float fadeDuration = 7f; // Duration of the fade-out
    public static AudioManager instance;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            if(!isIntro)
            {
            DontDestroyOnLoad(gameObject);
            }
        }else{
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Toca o som assim que o jogo inicia
        }
        else
        {
            Debug.LogWarning("AudioSource não configurado!");
        }

    }

    void Update()
    {
        // Verifica se o AudioSource está tocando
        if(isIntro)
        {
         
        if (audioSource != null && audioSource.isPlaying)
        {
            // Verifica se o tempo de áudio restante é menor que a duração do fade-out
            if (audioSource.clip.length - audioSource.time <= fadeDuration)
            {
                FadeOut();
            }
        }
        }else{

        }
    }

    // Method to start the fade-out
    public void FadeOut()
    {
        if (audioSource != null)
        {
            StartCoroutine(FadeOutCoroutine());
        }
    }

    private IEnumerator FadeOutCoroutine()
    {
        float startVolume = audioSource.volume;

        // Gradually decrease volume
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null; // Wait for the next frame
        }

        // Ensure the volume is set to 0 and stop the audio
        audioSource.volume = 0;
        audioSource.Stop();
    }
}
