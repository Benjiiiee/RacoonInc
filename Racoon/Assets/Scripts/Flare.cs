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
    private bool isYeeted = false;

    //Sound

    bool stopSound = false;
    public AK.Wwise.Event startFlareSound;
    public AK.Wwise.Event stopFlareSoundFade;
    public AK.Wwise.Event stopFlareSoundImmediate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.isKinematic = true;
        LightRadiusStart();
        startFlareSound.Post(gameObject);
    }

    void Update()
    {
        if(isYeeted)
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
                    if (timeLeft2 < 2.5f && !stopSound)
                    {
                        stopSound = true;
                        stopFlareSoundFade.Post(gameObject);
                    }
                    if (timeLeft2 < 0)
                    {
                        Destroy(this.gameObject);
                    }
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

    public void Yeet()
    {
        rb.isKinematic = false;
        isYeeted = true;
        LightRadiusYeet();
    }

    void LightRadiusStart()
    {
        light1.pointLightInnerRadius /= 5f;
        light2.pointLightInnerRadius /= 5f;
        light3.pointLightInnerRadius /= 5f;
                                      
        light1.pointLightOuterRadius /= 5f;
        light2.pointLightOuterRadius /= 5f;
        light3.pointLightOuterRadius /= 5f;
    }                                  
                                       
    void LightRadiusYeet()             
    {                                  
        light1.pointLightInnerRadius *= 5f;
        light2.pointLightInnerRadius *= 5f;
        light3.pointLightInnerRadius *= 5f;
                                    
        light1.pointLightOuterRadius *= 5f;
        light2.pointLightOuterRadius *= 5f;
        light3.pointLightOuterRadius *= 5f;
    }

    public void StopFlareSoundImmediate()
    {
        stopFlareSoundImmediate.Post(gameObject);
    }
}
