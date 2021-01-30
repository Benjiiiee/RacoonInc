using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostMovementEvents : MonoBehaviour
{
    // Name the events
    public AK.Wwise.Event FootstepEvent;
    public AK.Wwise.Event FoleyEvent;

    // Post the footstep event

    public void PlayFootstepSound()
    {
        FootstepEvent.Post(gameObject);
    }

    // Post the foley event
    public void PlayFoleySound()
    {
        FoleyEvent.Post(gameObject);
    }
}
