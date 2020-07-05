﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthSystem healthInicial;
    public HealthBar healthBar;
    Vector2 movement;
    private Animator animator;
    public VectorValue StartingPosition;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = StartingPosition.inicial;
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = healthInicial.healthInicial;
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
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
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthInicial.healthInicial = currentHealth;
        healthBar.SetHealth(currentHealth);
    }
}
