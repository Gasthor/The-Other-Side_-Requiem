using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    //esta clase sirve para cualquier ataque parecido.
    public float speed;

    PlayerMovement pl;
    GameObject PlayerMovement;
    Rigidbody2D rb2d;

    Vector3 target, dir;

    void Start()
    {
        PlayerMovement = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();


        if (PlayerMovement != null)
        {
            target = PlayerMovement.transform.position;
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
        if (col.transform.tag == "Player" || col.transform.tag == "Player2" || col.transform.tag == "Attack") // ojo con los tag!!!!
        {
            if (col.transform.tag == "Player" || col.transform.tag == "Player2") col.SendMessage("TakeDamage", 10);
            Destroy(gameObject);

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
