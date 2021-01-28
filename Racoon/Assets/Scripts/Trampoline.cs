using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public GameObject character;
    public GameObject flare;
    public Vector2 customVelocity;
    Vector2 velocity;
    bool onTop;
      
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D()
    {
        onTop = true;

    }

    void OnTriggerExit2D()
    {
        onTop = false;
    }
}
