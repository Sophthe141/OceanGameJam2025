using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject leftImage;
    public GameObject rightImage;
    void Start()
    {
        leftImage.SetActive(false);
        rightImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData){
        leftImage.SetActive(true);
        rightImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        leftImage.SetActive(false);
        rightImage.SetActive(false);
    }
}
