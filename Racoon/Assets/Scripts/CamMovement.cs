using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject camera;
    public GameObject character;
    public GameObject firstCamPositionTemplate;
    public GameObject nextCamPositionTemplate;
    private bool isFirst = true;
    private bool isSecond = false;
    private bool wentFirst = false;
    private bool wentSecond = false;
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
            if (isFirst == true)
            {
                inTrigger = true;
                camera.transform.position = new Vector3(nextCamPositionTemplate.transform.position.x, nextCamPositionTemplate.transform.position.y, camera.transform.position.z);
                isFirst = false;
                wentFirst = true;
            }
            if (isSecond == true)
            {
                inTrigger = true;
                camera.transform.position = new Vector3(firstCamPositionTemplate.transform.position.x, firstCamPositionTemplate.transform.position.y, camera.transform.position.z);
                isSecond = false;
                wentSecond = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D character)
    {
        if (character.gameObject.CompareTag("Player"))
        {
            if (isFirst == false && wentFirst == true && inTrigger == true)
            {
                inTrigger = false;
                isSecond = true;
                wentFirst = false;
            }
            if (isSecond == false && wentSecond == true && inTrigger == true)
            {
                inTrigger = false;
                isFirst = true;
                wentSecond = false;
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
