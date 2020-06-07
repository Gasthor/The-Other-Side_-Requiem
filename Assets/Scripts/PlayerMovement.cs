using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    Vector2 movement;
    private Animator animator;
    public VectorValue StartingPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = StartingPosition.inicial;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement != Vector2.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }
    }
   
    void MoveCharacter()
    {
        rb.MovePosition(rb.position + movement*moveSpeed*Time.fixedDeltaTime);

    }
}
