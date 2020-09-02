using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
        if (healthInicial.healthInicial > 0)
        {
            animator.SetBool("Alive", true);
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
        else
        {
            animator.SetBool("Alive", false);
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
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthInicial.healthInicial = currentHealth;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            currentHealth = 0;
            healthInicial.healthInicial = currentHealth;
            healthBar.SetHealth(currentHealth);
        }
        
    }
    void Health(int health)
    {
        currentHealth += health;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthInicial.healthInicial = currentHealth;
        healthBar.SetHealth(currentHealth);
    }
    void Attack()
    {
        Vector2 vec = Vector2.zero;
        animator.SetTrigger("Attacking");
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (animator.GetFloat("MoveX") == -1)
        {
            vec.x = -1;
            rb.velocity = vec * bulletForce;
        }
        if (animator.GetFloat("MoveX") == 1)
        {
            vec.x = 1;
            rb.velocity = vec * bulletForce;
        }
        if (animator.GetFloat("MoveY") == -1)
        {
            vec.y = -1;
            rb.velocity = vec * bulletForce;
        }
        if (animator.GetFloat("MoveY") == 1)
        {
            vec.y = 1;
            rb.velocity = vec * bulletForce;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "P2" && !animator.GetBool("Alive"))
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                currentHealth = 35;
                healthInicial.healthInicial = currentHealth;
                healthBar.SetHealth(currentHealth);
            } 
        }
    }
}

