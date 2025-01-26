using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteract : MonoBehaviour
{
    public GameObject menuPainel;
    public GameObject creditPainel;
    void Start()
    {
        menuPainel.SetActive(true);
        creditPainel.SetActive(false);
    }

    public void SetMenu(){
        menuPainel.SetActive(true);
        creditPainel.SetActive(false);
    }

    public void SetCredit(){
        menuPainel.SetActive(false);
        creditPainel.SetActive(true);
    }
}
