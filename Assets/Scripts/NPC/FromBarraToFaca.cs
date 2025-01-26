using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromBarraToFaca : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;

    private Transform transformers;

    [SerializeField] private Transform target;

    private bool isPlayerInTrigger = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        transformers = GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPlayerInTrigger)
        {
            isPlayerInTrigger = true;
            animator.Play("UsingFaca");
            transformers.position = new Vector3(target.position.x, target.position.y, target.position.z);

            Debug.Log("Desceu");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isPlayerInTrigger)
        {
            isPlayerInTrigger = false;
            animator.Play("AFazerBarra");
            transformers.position = new Vector3(target.position.x, target.position.y - 1.1f, target.position.z);
        }
    }
}
