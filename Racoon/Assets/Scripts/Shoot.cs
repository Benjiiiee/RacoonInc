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

    void Start()
    {
        character = GetComponentInParent<CharacterController>();
        SpawnPoints();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && character.jumpState == CharacterController.JumpState.Grounded)
        {
            isThrowing = true;
            character.controlEnabled = false;
            firstPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            Shootit();
            ResetPoints();
            character.controlEnabled = true;
            isThrowing = false;
        }

    }

    void Aim()
    {
        transform.right = direction;
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = Pointposition(i * spaceBetweenPoints);
        }
    }

    void Shootit()
    {
        GameObject newFlare = Instantiate(flare, shotPoint.position, shotPoint.rotation);
        newFlare.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        Physics2D.IgnoreCollision(newFlare.GetComponent<Collider2D>(), character.GetComponent<Collider2D>(), true);
    }

    Vector2 Pointposition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
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
}
