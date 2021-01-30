using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class LightUpIngredient : MonoBehaviour
{
    public Light2D light1;
    public Light2D light2;
    public Light2D light3;
    private bool isOn = false;
    float timeToLight = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flare"))
        {
            isOn = true;
            TurnOn();
        }
    }

    void TurnOn()
    {
        light1.GetComponent<Light2D>().enabled = true;
    }

}


