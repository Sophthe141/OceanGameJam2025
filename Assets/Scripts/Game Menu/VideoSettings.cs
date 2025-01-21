using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    public GameObject volumeScreen;

    public void SetResolution1(){
        Screen.SetResolution(1920, 1080, true);
    }

    public void SetResolution2(){
        Screen.SetResolution(1280, 1536, true);
    }

    public void SetActiveCurveScreen(){
        volumeScreen.SetActive(true);
    }

    public void setDisableCurveScreen(){
        volumeScreen.SetActive(false);
    }

    public void setCRTShader(){
        Debug.Log("CRT Shader");
    }

    public void setDisableCRTShader(){
        Debug.Log("Disable CRT Shader");
    }
}
