using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killplane : MonoBehaviour
{
    public GameObject camera;
    public GameObject firstCamTrigger;
    public GameObject secondCamTrigger;
    public GameObject thirdCamTrigger;
    public GameObject camPosition;
    private CamMovement firstCamScript;
    private CamMovement secondCamScript;
    private CamMovement thirdCamScript;

    void Start()
    {
        firstCamScript = firstCamTrigger.GetComponent<CamMovement>();
        secondCamScript = secondCamTrigger.GetComponent<CamMovement>();
        thirdCamScript= thirdCamTrigger.GetComponent<CamMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<CharacterController>().Respawn();
            camera.transform.position = new Vector3(camPosition.transform.position.x, camPosition.transform.position.y, camera.transform.position.z);
            firstCamScript.Reset();
            secondCamScript.Reset();
            thirdCamScript.Reset();
            
        }
    }
}
