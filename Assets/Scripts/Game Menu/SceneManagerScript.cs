using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
