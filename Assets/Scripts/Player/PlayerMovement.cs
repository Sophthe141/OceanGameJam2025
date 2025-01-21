using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    private bool isJumping = false;
    public float speed = 7f;
    public float jumpForce = 10f; // Acts as upward swim force in water
    public Vector2 totalMovement;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetMovement(InputAction.CallbackContext value)
    {
        totalMovement = value.ReadValue<Vector2>().normalized;
        if(!isJumping)
        rb.velocity = new Vector2(speed * totalMovement.x, rb.velocity.y);
        Debug.Log("Velovity Y:"+rb.velocity.y);
    }

    public void JumpMoviment(InputAction.CallbackContext value)
    {
        if (!DialogueManager.instance.dialogueIsPlaying && !PauseSystem.GameIsPaused)
            {
        if(value.phase == InputActionPhase.Started)
        {
                isJumping = true;
                //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x , jumpForce);
        }
        if (value.phase == InputActionPhase.Performed)
        {
            
                Debug.Log("HOLDING JUMP");
            
        }
        if(value.phase == InputActionPhase.Canceled)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            isJumping = false;
        }
        }
    }

    void Update()
    {
        if (DialogueManager.instance.dialogueIsPlaying || PauseSystem.GameIsPaused)
        {
            totalMovement = Vector2.zero;
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }
        move();
    }

    void move()
    {
        // Flip sprite based on horizontal movement direction
        if (totalMovement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (totalMovement.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Allow movement in all directions with velocity adjustments
        animator.SetFloat("Speed", Mathf.Abs(totalMovement.x) + Mathf.Abs(totalMovement.y));
        animator.SetFloat("InputX", totalMovement.x);
        animator.SetFloat("InputY", totalMovement.y);
    }
}
