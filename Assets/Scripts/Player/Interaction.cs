using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private GameObject interactAnimation;

    public string detectionTag;
    public bool isInteracting;
    public bool hasDetected = false;

    [SerializeField] private bool isDetecting;
    //private bool isDriving;

    void Start(){
        hasDetected = false;
        //isDriving = GameObject.FindGameObjectWithTag("Vehicle").GetComponent<LifterControls>().isDriving;
       
    }

    void FixedUpdate()
    {

        if(isDetecting){
                if(!hasDetected){
                    interactAnimation.SetActive(true);
                }
                if(CheckInteraction()){
                    hasDetected = true;
                }
            
        }else{
            interactAnimation.SetActive(false);
            isDetecting = false;
        }

        if(!DialogueManager.instance.dialogueIsPlaying && hasDetected && CheckInteraction()){
            hasDetected = false;
            isInteracting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(detectionTag)){
            //Debug.Log("Interactor: "+other.gameObject);
           // Debug.Log("Interactor Distance: "+((float)other.gameObject.transform.position.x - (float)this.gameObject.transform.position.x));
            //Debug.Log("Interactor Tag: "+other.gameObject.tag);

            isDetecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(detectionTag)){
            isDetecting = false;
        }
    }

    private bool CheckInteraction(){
        isInteracting = InputManager.instance.isInteracting;
        return isInteracting;
    }
} 
