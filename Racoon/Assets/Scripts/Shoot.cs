using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject flare;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
        
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
          
        }
        
    }

    void Shootit()
    {
        GameObject newFlare = Instantiate(flare, shotPoint.position, shotPoint.rotation);
        newFlare.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    Vector2 Pointposition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
