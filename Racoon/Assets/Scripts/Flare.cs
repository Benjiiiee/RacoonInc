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
    private bool switchingOff = false;
    float timeLeft = 5.0f;
    float timeLeft2 = 6.0f;

    //Sound

    bool stopSound = false;
    public AK.Wwise.Event startFlareSound;
    public AK.Wwise.Event stopFlareSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    private void Start()
    {
        startFlareSound.Post(gameObject);
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
       // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (switchingOff == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                eteint();
                timeLeft2 -= Time.deltaTime;
                if(timeLeft2 < 2.5f && !stopSound)
                {
                    stopSound = true;
                    stopFlareSound.Post(gameObject);
                }
                if (timeLeft2 < 0)
                {
                    Destroy(this.gameObject);
                }
                }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switchingOff = true;
    }

    private void eteint() 
    {
        light1.pointLightInnerRadius -= light1.pointLightInnerRadius * 0.002f;
        light2.pointLightInnerRadius -= light2.pointLightInnerRadius * 0.002f;
        light3.pointLightInnerRadius -= light3.pointLightInnerRadius * 0.002f;

        light1.pointLightOuterRadius -= light1.pointLightOuterRadius * 0.002f;
        light2.pointLightOuterRadius -= light2.pointLightOuterRadius * 0.002f;
        light3.pointLightOuterRadius -= light3.pointLightOuterRadius * 0.002f;
    }
}
