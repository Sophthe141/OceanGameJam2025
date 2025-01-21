using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {

    public List<Image> images; // Lista de imagens a serem exibidas
    public float timePerImage = 2f; // Tempo em segundos para exibir cada imagem
    IEnumerator ShowImages() {
        // Loop para cada imagem na lista
        foreach (Image image in images) {
            image.enabled = true; // Ativa a imagem atual
            
            // Espera o tempo especificado antes de passar para a próxima imagem
            yield return new WaitForSeconds(timePerImage);
            
            image.enabled = false; // Desativa a imagem atual
        }
         SceneManager.LoadScene("Fase1");
    }

    void Start() {
        StartCoroutine(ShowImages()); // Inicia a coroutine
    }
}
