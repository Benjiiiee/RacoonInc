using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Flicker_Effect : MonoBehaviour
{
    public float inRadiusRange;
    public float outRadiusRange;
    float inRadiusStartValue;
    float outRadiusStartValue;
    Light2D light2D;
    float randomSeed;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        inRadiusStartValue = light2D.pointLightInnerRadius;
        outRadiusStartValue = light2D.pointLightOuterRadius;
        randomSeed = Random.Range(0.0f, 65000f);
    }

    // Update is called once per frame
    void Update()
    {
        float noise = Mathf.PerlinNoise(randomSeed, Time.time);
        light2D.pointLightInnerRadius = Mathf.Lerp(inRadiusStartValue - inRadiusRange, inRadiusStartValue + inRadiusRange, noise);
        light2D.pointLightOuterRadius = Mathf.Lerp(outRadiusStartValue - outRadiusRange, outRadiusStartValue + outRadiusRange, noise);
    }
}
