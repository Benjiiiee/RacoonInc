using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject camera;
    public GameObject character;
    public bool isRight;
    public bool isLeft;
    public bool isUp;
    public bool isDown;
    public bool isRightLeftTrigger;
    public bool isUpDownTrigger;
    private bool wentRight = false;
    private bool wentLeft = false;
    private bool wentUp = false;
    private bool wentDown = false;
    private bool inTrigger;
  
    
    
    void Start()
    {
        inTrigger = false;
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D character)
    {
        if (character.gameObject.CompareTag("Player"))
        {
            if (isRight == true)
            {
                inTrigger = true;
                camera.transform.Translate(30.0f, 0f, 0f);
                isRight = false;
                wentRight = true;


            }
            if (isLeft == true)
            {
                inTrigger = true;
                camera.transform.Translate(-30.0f, 0f, 0f);
                isLeft = false;
                wentLeft = true;

            }
            if (isUp == true)
            {
                inTrigger = true;
                camera.transform.Translate(0f, 17.0f, 0f);
                isUp = false;
                wentUp = true;

            }
            if (isDown == true)
            {
                inTrigger = true;
                camera.transform.Translate(0f, -17.0f, 0f);
                isDown = false;
                wentDown = false;

            }
        }
    }
    void OnTriggerExit2D(Collider2D character)
    {
        if (character.gameObject.CompareTag("Player"))
        {
            if (isRight == false && isRightLeftTrigger == true && wentRight == true && inTrigger == true)
            {
                inTrigger = false;
                isLeft = true;
                wentRight = false;
            }
            if (isLeft == false && isRightLeftTrigger == true && wentLeft == true && inTrigger == true)
            {
                inTrigger = false;
                isRight = true;
                wentLeft = false;
            }
            if (isUp == false && isUpDownTrigger == true && wentUp == true && inTrigger == true)
            {
                inTrigger = false;
                isDown = true;
                wentUp = false;
            }
            if (isDown == false && isUpDownTrigger == true && wentDown == true && inTrigger == true)
            {
                inTrigger = false;
                isUp = true;
                wentDown = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D character)
    {
        if (character.gameObject.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }
}
