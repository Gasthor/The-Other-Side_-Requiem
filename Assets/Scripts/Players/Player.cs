using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    //
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    //
    public int maxHealth = 100;
    public int currentHealth;
    public HealthSystem healthInicial;
    public HealthBar healthBar;
    //
    Vector2 movement;
    private Animator animator;
    public VectorValue StartingPosition;

    public bool canMove; //NUEVO
    public Rigidbody2D rb2D;
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = StartingPosition.inicial;
        //
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = healthInicial.healthInicial;
        healthBar.SetHealth(currentHealth);
        //

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //----------------------------------------
        if (!canMove) //NUEVO
        {
            rb2D.velocity = Vector3.zero;
            return;
        }
        
        //-------------------------------------
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
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
        if (Input.GetKeyDown(KeyCode.Space)&&(movement.x!=0 || movement.y!=0))
        {
            Attack();
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    TakeDamage(20);
        //}
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
    void Attack()
    {
        Vector2 vec = Vector2.zero;
        animator.SetTrigger("Attacking");
        GameObject bullet = Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (movement.x == -1)
        {
            vec.x = -1;
            rb.velocity = vec * bulletForce;
        }
        if (movement.x == 1)
        {
            vec.x = 1;
            rb.velocity = vec * bulletForce;
        }
        if (movement.y == -1)
        {
            vec.y = -1;
            rb.velocity = vec * bulletForce;
        }
        if (movement.y == 1)
        {
            vec.y = 1;
            rb.velocity = vec * bulletForce;
        }
    }
}
