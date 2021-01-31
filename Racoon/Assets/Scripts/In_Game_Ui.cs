using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Game_Ui : MonoBehaviour
{
    public GameObject player;
    public GameObject filled1;
    public GameObject filled2;
    public GameObject filled3;
    public GameObject filled4;
    public GameObject filled5;
    // Start is called before the first frame update
    void Start()
    {
        player  = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Has0Flare()
    {
        filled1.SetActive(false);
        filled2.SetActive(false);
        filled3.SetActive(false);
        filled4.SetActive(false);
        filled5.SetActive(false);
    }
    public void Has1Flare() 
    {
        filled1.SetActive(true);
        filled2.SetActive(false);
        filled3.SetActive(false);
        filled4.SetActive(false);
        filled5.SetActive(false);
    }
    public void Has2Flare()
    {
        filled1.SetActive(true);
        filled2.SetActive(true);
        filled3.SetActive(false);
        filled4.SetActive(false);
        filled5.SetActive(false);
    }
    public void Has3Flare()
    {
        filled1.SetActive(true);
        filled2.SetActive(true);
        filled3.SetActive(true);
        filled4.SetActive(false);
        filled5.SetActive(false);
    }
    public void Has4Flare()
    {
        filled1.SetActive(true);
        filled2.SetActive(true);
        filled3.SetActive(true);
        filled4.SetActive(true);
        filled5.SetActive(false);
    }
    public void Has5Flare()
    {
        filled1.SetActive(true);
        filled2.SetActive(true);
        filled3.SetActive(true);
        filled4.SetActive(true);
        filled5.SetActive(true);
    }
}
