using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Vector3 cam;
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = cam.x;
        pos.y = cam.y;
        pos.z = cam.z;
        transform.position = pos;
    }
}

