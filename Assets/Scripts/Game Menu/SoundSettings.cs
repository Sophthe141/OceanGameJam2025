using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider volumeSlider;

    private AudioManager audioManager; // Referência ao AudioManager

    private void Awake()
    {
        // Tenta encontrar o AudioManager na cena
        audioManager = FindObjectOfType<AudioManager>();

        if (audioManager == null)
        {
            Debug.LogError("AudioManager não encontrado! Certifique-se de que ele está ativo na cena.");
        }
    }

    private void Start()
    {
        if (audioManager == null || volumeSlider == null) return;

        // Configura o valor inicial do slider com base no volume atual do AudioSource
        if (audioManager.audioSource != null)
        {
            volumeSlider.value = audioManager.audioSource.volume;
        }
        else
        {
            Debug.LogWarning("AudioSource não configurado no AudioManager!");
        }

        // Adiciona um listener para detectar mudanças no valor do slider
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float newVolume)
    {
        // Atualiza o volume do AudioSource no AudioManager
        if (audioManager != null && audioManager.audioSource != null)
        {
            audioManager.audioSource.volume = newVolume;
        }
    }
}