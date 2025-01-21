using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{  
    private Rigidbody2D rb;
    public bool isDriving = false;
     public Animator animator;

    public float speed = 7f;
    public Vector2 totalMovement;
 

    private SpriteRenderer spriteRenderer;
    private void Awake() {
       rb = GetComponent<Rigidbody2D>(); 
       spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    public void SetMovement(InputAction.CallbackContext value)
    { 
        
        totalMovement = value.ReadValue<Vector2>().normalized;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.instance.dialogueIsPlaying || PauseSystem.GameIsPaused)
        {
            totalMovement = new Vector2(0,0);
            rb.velocity = new Vector2(0,0);
            animator.SetFloat("Speed", 0);    
            return; 
        }else{
            move();
        }
           
        
       
    }

    void move()
    {
        
        if(totalMovement.x < 0 ){
            spriteRenderer.flipX = true;
        } else if(totalMovement.x > 0 ){
            spriteRenderer.flipX = false;
        }
        rb.velocity = new Vector2(speed * totalMovement.x, speed * totalMovement.y);
        animator.SetFloat("Speed", Mathf.Abs(totalMovement.x)+Mathf.Abs(totalMovement.y));
        animator.SetFloat("InputX", totalMovement.x);
        animator.SetFloat("InputY", totalMovement.y);
        
    }
}
