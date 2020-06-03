using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 4f;
    private Animator animator;
    public Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            movement.x = -1;
            movement.y = 0;
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            animator.SetFloat("moveX", -1);
            animator.SetFloat("moveY", 0);
            animator.SetBool("move", true);
        }
        if (Input.GetKey("right"))
        {
            movement.x = 1;
            movement.y = 0;
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            animator.SetFloat("moveX", 1);
            animator.SetFloat("moveY", 0);
            animator.SetBool("move", true);
        }
        if (Input.GetKey("up"))
        {
            movement.x = 0;
            movement.y = 1;
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            animator.SetFloat("moveY", 1);
            animator.SetFloat("moveX", 0);
            animator.SetBool("move", true);
        }
        if (Input.GetKey("down"))
        {
            movement.x = 0;
            movement.y = -1;
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            animator.SetFloat("moveY", -1);
            animator.SetFloat("moveX", 0);
            
            animator.SetBool("move", true);
        }
        if(!Input.GetKey("left") && !Input.GetKey("right") && !Input.GetKey("up") && !Input.GetKey("down"))
        {
            animator.SetBool("move", false);
        }
    }
}
