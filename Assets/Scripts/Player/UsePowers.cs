    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePowers : MonoBehaviour
{
    
    private Animator animator;
    //private bool isUsingPower = false;

    private GameObject[] power;
    private int currentPower = 0;
    private int maxPower = 2;

    void Start()
    {
        animator = GetComponent<Animator>();
        power = new GameObject[transform.childCount];
        foreach (Transform child in transform)
        {
            if(child.tag == "Power" && currentPower < maxPower)
            {
                Debug.Log("Power" + child.gameObject.name);
                power[currentPower] = child.gameObject;
                currentPower++;
            }
        }

    }

    void update()
    {
            if(InputManager.instance.isUsingPower)
            {
                Debug.Log("Power");
                StartCoroutine(UsePower());
            }
        
    }

    void selectPower()
    {
        
    }

    IEnumerator UsePower()
    {
        if(power[currentPower].name == "Attack")
        {
            animator.Play("Attack");
            yield return new WaitForSeconds(0.5f);
            power[currentPower].SetActive(true);
            yield return new WaitForSeconds(1);
            power[currentPower].SetActive(false);
        }else{
            animator.Play("Defense");
            power[currentPower].SetActive(true);
        }
        
    }
}
