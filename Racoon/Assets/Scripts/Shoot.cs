using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject flare;
    public float launchForce, launchMin = 0f, launchMax = 15f;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    public Vector2 firstPoint, secondPoint, direction;
    private CharacterController character;
    private bool isThrowing = false;
    public float angularVelocity = 1f;
    Flare newFlare;
    public int flareCount = 5;
    public Transform yeetHandLeft;
    public Transform yeetHandRight;

    public GameObject canvas;
    public In_Game_Ui canvasScript;
    //Sound

    public AK.Wwise.Event throwFlareEvent;

    void Start()
    {
        character = GetComponentInParent<CharacterController>();
        SpawnPoints();
        canvas = GameObject.Find("Canvas");
        canvasScript = canvas.GetComponent<In_Game_Ui>();
        UpdateUI(flareCount);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && character.jumpState == CharacterController.JumpState.Grounded && flareCount > 0)
        {
            newFlare = Instantiate(flare, shotPoint.position, shotPoint.rotation).GetComponent<Flare>();
            throwFlareEvent.Post(gameObject);
            isThrowing = true;
            character.controlEnabled = false;
            firstPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            character.animator.SetBool("isrunning", false);
            character.animator.SetBool("isyeeting", true);


        }

        if (Input.GetMouseButton(0) && isThrowing)
        {
            secondPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = -(secondPoint - firstPoint);
            launchForce = Mathf.Clamp(Vector2.Distance(firstPoint, secondPoint), launchMin, launchMax);
            Aim();
            
        }

        if (Input.GetMouseButtonUp(0) && isThrowing)
        {
            character.animator.SetBool("isyeeting", false);
            Shootit();
            ResetPoints();
            character.controlEnabled = true;
            isThrowing = false;
        }

        //Cancel throw
        if(Input.GetMouseButtonDown(1))
        {
            character.animator.SetBool("isyeeting", false);
            CancelFlare();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            RefuelFlare();
        }
    }

    void Aim()
    {
        transform.right = direction;
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = Pointposition(i * spaceBetweenPoints);
            if(i == numberOfPoints - 1)
            {
                if(points[i].transform.position.x < character.transform.position.x)
                {
                    character.spriteRenderer.flipX = true;
                    newFlare.transform.position = yeetHandRight.position;
                }
                else
                {
                    character.spriteRenderer.flipX = false;
                    newFlare.transform.position = yeetHandLeft.position;
                }
            }
        }
    }

    void Shootit()
    {
        if (flareCount > 5)
            flareCount = 5;
        flareCount -= 1;
        newFlare.Yeet();
        newFlare.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        newFlare.GetComponent<Rigidbody2D>().angularVelocity = character.spriteRenderer.flipX ? launchForce * 50 : -launchForce * 50;
        Physics2D.IgnoreCollision(newFlare.GetComponent<Collider2D>(), character.GetComponent<Collider2D>(), true);
        UpdateUI(flareCount);
    }

    Vector2 Pointposition(float t)
    {
        Vector2 position = (Vector2)newFlare.transform.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    void SpawnPoints()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, new Vector2(-1000f, -1000f), Quaternion.identity);
        }
    }

    void ResetPoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = new Vector2(-1000f, -1000f);

        }
    }

    void CancelFlare()
    {
        if(!newFlare.isYeeted)
        {
            newFlare.StopFlareSoundImmediate();
            Destroy(newFlare.gameObject);
            isThrowing = false;
            character.controlEnabled = true;
            ResetPoints();
        }
    }

    public void RefuelFlare()
    {
        flareCount = 5;
        UpdateUI(flareCount);
    }

    public void UpdateUI(int actualFlareCount) 
    {
    switch (actualFlareCount)
        {

            case 0:
                canvasScript.Has0Flare();
                break;
            case 1:
                canvasScript.Has1Flare();
                break;
            case 2:
                canvasScript.Has2Flare();
                break;
            case 3:
                canvasScript.Has3Flare();
                break;
            case 4:
                canvasScript.Has4Flare();
                break;
            case 5:
                canvasScript.Has5Flare();
                break;
            default:
                canvasScript.Has5Flare();
                break;
        }
    }
}
