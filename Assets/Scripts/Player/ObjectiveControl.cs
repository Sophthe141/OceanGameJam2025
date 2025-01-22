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
      
        
        progressText.text = string.Format("Bolhas {0}/{1}", ObjectiveProgress, MaxProgress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CleanChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble") && ObjectiveProgress < MaxProgress)
        {
            isCollidingWithBubble = true;
            ObjectiveProgress++;
            other.gameObject.SetActive(false);
            progressText.text = string.Format("Bolhas {0}/{1}", ObjectiveProgress, MaxProgress);
            ObjectiveEvent.Invoke();
        }
    }
}
