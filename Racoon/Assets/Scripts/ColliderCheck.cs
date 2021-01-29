using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public bool colliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.tag != "Player")
                colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }
}
