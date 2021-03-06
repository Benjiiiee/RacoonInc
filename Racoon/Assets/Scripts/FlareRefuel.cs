﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareRefuel : MonoBehaviour
{
    private Collider2D collider;
    private SpriteRenderer renderer;
    private CharacterController character;

    public AK.Wwise.Event pickupSound;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
        character = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        character.resetCollectibles.AddListener(Init);
    }

    public void Init()
    {
        collider.enabled = true;
        renderer.enabled = true;
    }

    public void TurnOff()
    {
        pickupSound.Post(gameObject);
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
