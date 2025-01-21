using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    // Start is called before the first frame update

    public static void PauseGame(){
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public static void ResumeGame(){
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
