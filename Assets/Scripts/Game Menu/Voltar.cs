using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voltar : MonoBehaviour
{
    [Header("Voltar")]
    [SerializeField] private GameObject atual;
    
    [SerializeField] private GameObject anterior;
    // Start is called before the first frame update
    public void backButton(){
        atual.SetActive(false);
        anterior.SetActive(true);
    }
}
