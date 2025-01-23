using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Animator animator;
    public float speed = 7f;
    public float jumpForce = 10f; // Acts as upward swim force in water
    public Vector2  totalMovement;
    private Transform[] childList;
    private Rigidbody2D rb;

    [SerializeField] private bool isDetectingPlayer;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        foreach (Transform child in transform)
        {
            //if (child.GetComponent<SpriteRenderer>() != null && spriteRenderer == null)
            //{

            spriteRenderer = child.GetComponent<SpriteRenderer>();

            // }
        }
    }


    public void SetMovement(Transform targetTransform)
    {

        
        if (targetTransform.position.x > transform.position.x)
        {
            //Debug.Log("Moving Left"+" PlayerPOS:"+targetTransform.position.x+" EnemyPOS:"+transform.position.x);
            totalMovement.x = 1;
        }
        else
        {
            totalMovement.x = -1;
        }
        if (targetTransform.position.y > transform.position.y)
        {
            totalMovement.y = 1;
        }
        else
        {
            totalMovement.y = -1;
        }

        Vector2 DistanceCalculated = targetTransform.position - transform.position;
        move(Mathf.Atan2(DistanceCalculated.y, DistanceCalculated.x) * Mathf.Rad2Deg);
        
    }

    void move(float angle)
    {
        
        if (angle <= 90 && angle >= -90)
        {

            spriteRenderer.flipY = false;
        }
        else if (angle > 90 || angle <= 100)
        {

            spriteRenderer.flipY = true;
        }
        else if (angle >= -100 && angle < -90)
        {
            spriteRenderer.flipY = false;
        }else{
            spriteRenderer.flipY = true;
        }

        if(angle == 90 || angle == -90){
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle - 1f));
        }else{
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        

        Debug.Log("Angle: " + angle);
        rb.velocity =  totalMovement * speed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isDetectingPlayer = true;

            SetMovement(other.transform);
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 0);
            rb.velocity = Vector2.zero;
            spriteRenderer.flipY = false;
        }

    }


}