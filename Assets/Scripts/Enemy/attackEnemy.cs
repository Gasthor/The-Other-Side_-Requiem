using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    //esta clase sirve para cualquier ataque parecido.
    public float speed;
    public int damage;

    private GameObject Player;
    private GameObject Player2;
    public Indicador indicador;
    Rigidbody2D rb2d;

    Vector3 target, dir;

    void Start()
    {
        Player = GameObject.Find("P1");
        Player2 = GameObject.Find("P2");
        rb2d = GetComponent<Rigidbody2D>();
        

        if (indicador.indicador == 1)
        {
            target = Player.transform.position;
            dir = (target - transform.position).normalized;
        }
        if(indicador.indicador == 2)
        {
            target = Player2.transform.position;
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
            if (col.transform.tag == "Player" )
            {
                col.SendMessage("TakeDamage", damage);
            }
            Destroy(gameObject);
        }
        if (!col.CompareTag("Enemy") && !col.CompareTag("Magia") && !col.CompareTag("MagiaEnemigo"))
        {
            Destroy(gameObject);
        }
        
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
