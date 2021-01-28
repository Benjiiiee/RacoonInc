using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject camera;
    public bool isRight;
    public bool isLeft;
    public bool isUp;
    public bool isDown;
    public bool isRightLeftTrigger;
    public bool isUpDownTrigger;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {
        if (isRight == true && isRightLeftTrigger)
        {
            camera.transform.Translate(25.0f, 0f, 0f);
            isRight = false;
            isLeft = true;
           
            
        }
        if (isLeft == true && isRightLeftTrigger)
        {
            camera.transform.Translate(-25.0f, 0f, 0f);
            isLeft = false;
            isRight = true;
            
        }
        if (isUp == true && isUpDownTrigger)
        {
            camera.transform.Translate(0f, 14.0f, 0f);
            isUp = false;
            isDown = true;
            
        }
        if (isDown == true && isUpDownTrigger)
        {
            camera.transform.Translate(0f, -14.0f, 0f);
            isDown = false;
            isUp = true;
            
        }
    }
    
}
