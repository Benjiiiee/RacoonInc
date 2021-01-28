using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject flare;
    public GameObject character;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;

    void Start()
    {
        SpawnPoints();

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            Vector2 handPosition = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - handPosition;
            transform.right = direction;
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = Pointposition(i * spaceBetweenPoints);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shootit();
            ResetPoints();

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
