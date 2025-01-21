using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotateMenu : MonoBehaviour
{   

    private float rotZ = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       
      
    }
    // Update is called once per frame*
    void Update()
    {  
       

         rotZ = rotZ + Time.deltaTime * 75;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
      

    }

    
    
}
