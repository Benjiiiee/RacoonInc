using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10f;
    public float walkForce = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.right * walkForce, ForceMode.Acceleration);
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    
}
