using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeParticles : MonoBehaviour
{
    Transform tr;
    Quaternion rotation;

    void Start()
    {
        tr = transform;
        rotation = tr.rotation;
    }

    private void FixedUpdate()
    {
        tr.rotation = rotation;
    }
}
