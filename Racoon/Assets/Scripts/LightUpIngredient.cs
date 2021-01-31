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
    public GameObject Flames;
    private bool isOn = false;
    public GameObject myTrampoline;
    public bool isJumpBrazier;
    // Start is called before the first frame update
    void Start()
    {
        myTrampoline.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flare"))
        {
            Flames.SetActive(true);
            isOn = true;
            TurnOn();
            
        }
        if (other.gameObject.CompareTag("Flare") && isJumpBrazier == true)
        {
            myTrampoline.SetActive(true);
        }
    }

    void TurnOn()
    {
        if (isJumpBrazier == true)
        {
            myTrampoline.SetActive(true);
        }
        light1.GetComponent<Light2D>().enabled = true;
        light2.GetComponent<Light2D>().enabled = true;
        light3.GetComponent<Light2D>().enabled = true;
    }

}


