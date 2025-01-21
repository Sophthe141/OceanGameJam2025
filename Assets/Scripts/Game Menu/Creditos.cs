using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{   
    [Header("Creditos")]
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject Menu;
    void Start()
    {
    creditos.SetActive(false);    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreditosButton(){
        creditos.SetActive(true);
        Menu.SetActive(false);
    }
}
