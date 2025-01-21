using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShowingUp : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float delayToStart = 1.0f;
    private float elapsedTime = 0.0f;
    [SerializeField]private Transform TargetPosition;
    [SerializeField]private float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < delayToStart)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            MoveUI();
        }
   
    }
    void MoveUI()
    {
        // Se o tempo decorrido for menor que a duração
        if (transform!=TargetPosition)
        {
            // Atualiza o tempo decorrido
            

            // Calcula o progresso do efeito (0 a 1)
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition.position, step);

            // Ajusta o campo de visão da câmera (suavemente)
        }
    }
}
