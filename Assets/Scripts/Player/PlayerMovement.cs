using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform light2D;

    public Animator animator;
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
        //if(!isJumping)
        rb.velocity = new Vector2(speed * totalMovement.x, speed * totalMovement.y);
        
    }

    

    void Update()
    {
        if ( PauseSystem.GameIsPaused || Life.isDead)
        {
            Debug.Log("Player is dead");    
            totalMovement = Vector2.zero;
            rb.velocity = new Vector2(0, -1);
            animator.SetFloat("Speed", 0);
            return;
        }
        move();
    }

    void move()
    {
        
        
        if (totalMovement.x < 0)
        {
            light2D.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            spriteRenderer.flipX = false;
        }
        else if (totalMovement.x > 0)
        {
            light2D.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
            spriteRenderer.flipX = true;
        }

        
        animator.SetFloat("Speed", Mathf.Abs(totalMovement.x) + Mathf.Abs(totalMovement.y));
        animator.SetFloat("InputX", totalMovement.x);
        animator.SetFloat("InputY", totalMovement.y);
    }
}
