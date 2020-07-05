using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 4f;
    Vector2 movement;
    private Animator animator;
    public VectorValue StartingPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = StartingPosition.inicial;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal2");
        movement.y = Input.GetAxisRaw("Vertical2");
        if (movement != Vector2.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void MoveCharacter()
    {
        if (movement.x == -1)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (movement.x == 1)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (movement.y == -1)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (movement.y == 1)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

    }
}
