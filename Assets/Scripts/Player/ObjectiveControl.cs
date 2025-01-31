using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;

public class ObjectiveControl : MonoBehaviour
{
   
    [SerializeField] public static int MaxProgress {get; private set;} = 3;
    public static int ObjectiveProgress {get; private set;} = 0;
    private bool isCollidingWithBubble = false;
    [SerializeField] private TextMeshProUGUI progressText;
    public UnityEvent ObjectiveEvent;
    // Start is called before the first frame update
    void Start()
    {
      
        ObjectiveProgress = 0;
        MaxProgress = 3;
        progressText.text = string.Format("Bolhas {0}/{1}", ObjectiveProgress, MaxProgress);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble") && ObjectiveProgress < MaxProgress)
        {
            isCollidingWithBubble = true;
            other.gameObject.SetActive(false);
            ObjectiveProgress++;
            progressText.text = string.Format("Bolhas {0}/{1}", ObjectiveProgress, MaxProgress);
            ObjectiveEvent.Invoke();
        }
    }
}
