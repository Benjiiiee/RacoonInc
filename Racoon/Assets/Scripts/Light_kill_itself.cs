using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_kill_itself : MonoBehaviour
{
    public float timeLeft;

    private void Start()
    {
            timeLeft = 3.0f;

}
void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f) 
        {
            this.gameObject.SetActive(false);
        }
    }
}
