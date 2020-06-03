using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            movement.x = -1;
            movement.y = 0;
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            movement.x = 1;
            movement.y = 0;
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            movement.x = 0;
            movement.y = 1;
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            movement.x = 0;
            movement.y = -1;
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
    }
}
