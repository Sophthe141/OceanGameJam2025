using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{
    [Header("Runtime Platform")]
    [SerializeField] private GameObject pcUI;
    [SerializeField] private GameObject consoleUI;
    [SerializeField] private GameObject androidUI;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            pcUI.SetActive(true);
            consoleUI.SetActive(false);
            androidUI.SetActive(false);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            pcUI.SetActive(false);
            consoleUI.SetActive(false);
            androidUI.SetActive(true);
        }
        else
        {
            pcUI.SetActive(false);
            consoleUI.SetActive(true);
            androidUI.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
