using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareRefuel : MonoBehaviour
{
    public Collider2D collider;
    public SpriteRenderer renderer;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Init()
    {
        collider.enabled = true;
        renderer.enabled = true;
    }

    public void TurnOff()
    {
        collider.enabled = false;
        renderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInChildren<Shoot>().RefuelFlare();
            TurnOff();
        }
    }
}
