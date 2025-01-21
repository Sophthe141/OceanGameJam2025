using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoveMenu : MonoBehaviour
{

    [SerializeField] private float speedRot = 20.0f;
    private float rotZ = 0.0f;
    private bool reachedDegree = false;
    // Start is called before the first frame update
    void Start()
    {


    }
    // Update is called once per frame*
    void Update()
    {
        Debug.Log("Angle:"+rotZ);

        if(rotZ > 20 && reachedDegree == false)
        {
            Debug.Log("Travou1"+rotZ);
            speedRot = speedRot * -1;
            reachedDegree = true;
        }
        else if(rotZ <= -20 &&  reachedDegree == true)
        {
            Debug.Log("Travou2"+rotZ);
            speedRot = Mathf.Abs(speedRot);   
            reachedDegree = false;
        }


          
            rotZ = rotZ + (Time.deltaTime * speedRot);
        
        


        transform.rotation = Quaternion.Euler(0, 0, rotZ);


    }



}
