using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimator : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        GetComponent<Animator>().Play(this.gameObject.name);
    }
}
