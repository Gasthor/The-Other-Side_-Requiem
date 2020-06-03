using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector3 cameraChange;
    public Vector3 playerChange;
    private CameraMov cam;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMov>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.cam += cameraChange;
            collision.transform.position += playerChange;
        }
    }
}
