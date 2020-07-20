using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    //esta clase sirve para cualquier ataque parecido.
    public float speed;
    public int damage;

    Player pl;
    GameObject Player;
    Rigidbody2D rb2d;

    Vector3 target, dir;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();


        if (Player != null)
        {
            target = Player.transform.position;
            dir = (target - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        if (target != Vector3.zero)
        {
            rb2d.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player" || col.transform.tag == "Attack") // ojo con los tag!!!!
        {
            if (col.transform.tag == "Player")
            {
                col.SendMessage("TakeDamage", damage);
            }
            Destroy(gameObject);
        }
        if (!col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
