using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;
//using UnityEngine.Experimental.Rendering.LWRP;

public class Flare : MonoBehaviour
{
    public GameObject character;
    Rigidbody2D rb;
    public Light2D light1;
    public Light2D light2;
    public Light2D light3;


    void Start()
    {

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        light1.pointLightInnerRadius -= light1.pointLightInnerRadius*0.001f;
        light2.pointLightInnerRadius -= light2.pointLightInnerRadius*0.001f;
        light3.pointLightInnerRadius -= light3.pointLightInnerRadius*0.001f;

        light1.pointLightOuterRadius -= light1.pointLightOuterRadius * 0.001f;
        light2.pointLightOuterRadius -= light2.pointLightOuterRadius * 0.001f;
        light3.pointLightOuterRadius -= light3.pointLightOuterRadius * 0.001f;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
