using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectItem : MonoBehaviour
{
    [Header("Collectable Settings")]
    [SerializeField] private GameObject collectableOnHUD1;
    [SerializeField] public int MaxCargoCarry = 1;
    [SerializeField] private GameObject collectableOnHUD2;  // Imagem do coletável na HUD
    public Collectable collectableScript; // Script do coletável
    public int currentCargoCarry = 0; // Quantidade de cargas que o player está carregando

    private bool isCarringCollectable = false;
    public bool IsCarringCollectable
    {
        get { return isCarringCollectable; }
        set { isCarringCollectable = value; } // Agora é gravável
    }

    void Start()
    {
        if (collectableScript != null)
        {
            collectableOnHUD1.SetActive(true);
            collectableOnHUD2.SetActive(false);
        }
    }

    void Update()
    {
        if (collectableScript != null && checkIfCollected())
        {
            Debug.Log("Coletável coletado");
        }
    }

    public bool checkIfCollected()
    {
        return collectableScript.hasCollected;
    }
}
