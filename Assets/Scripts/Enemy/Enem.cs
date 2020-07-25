using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem : MonoBehaviour {
    public float visionRadio;
    public float attackRadio;
    public float speed;
    bool attacking;
    public float attackSpeed;
    public Transform homePosition;
    public GameObject Objeto;

    
    public int health;
    public HealthSystem current;




    GameObject player;
    Vector3 initialPosition;
    Rigidbody2D rb2d;

    void Start()
    {
        health = current.healthInicial;

        if (current.healthInicial > 0)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            initialPosition = transform.position;
            rb2d = GetComponent<Rigidbody2D>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (current.healthInicial <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 target = initialPosition;
        //
        if (player != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                player.transform.position - transform.position,
                visionRadio,
                1 << LayerMask.NameToLayer("Default"));


            Vector3 forward = transform.TransformDirection(player.transform.position - transform.position); // debug??
            Debug.DrawRay(transform.position, forward, Color.red);// debug

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    target = player.transform.position;
                }
            }

            float distance = Vector3.Distance(target, transform.position);
            Vector3 dir = (target - transform.position).normalized;

            if (target != initialPosition && distance < attackRadio)
            {
                //animacion de ataque xd
                if (!attacking) StartCoroutine(Attack(attackSpeed));
            }
            else
            {
                //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
                // animacion de persecucion xd
            }

            if (target == initialPosition && distance < 0.02f)
            {
                transform.position = initialPosition;
            }
            Debug.DrawLine(transform.position, target, Color.green);// debug
            
        }
        /*
        if(player2 != null)
        {
            RaycastHit2D hit2 = Physics2D.Raycast(
                transform.position,
                player.transform.position - transform.position,
                visionRadio,
                1 << LayerMask.NameToLayer("Default"));


            Vector3 forward2 = transform.TransformDirection(player2.transform.position - transform.position); // debug??
            Debug.DrawRay(transform.position, forward2, Color.red);// debug

            if (hit2.collider != null)
            {
                if (hit2.collider.tag == "Player2")
                {
                    target2 = player.transform.position;
                }
            }

            float distance = Vector3.Distance(target2, transform.position);
            Vector3 dir = (target2 - transform.position).normalized;

            if (target2 != initialPosition && distance < attackRadio)
            {
                //animacion de ataque xd
                if (!attacking) StartCoroutine(Attack(attackSpeed));
            }
            else
            {
                //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);
                // animacion de persecucion xd
            }

            if (target2 == initialPosition && distance < 0.02f)
            {
                transform.position = initialPosition;
            }
            Debug.DrawLine(transform.position, target2, Color.green);// debug
        }
        */
    }

    IEnumerator Attack(float seconds)
    {
        attacking = true;

        if (player != homePosition && Objeto != null)
        {
            Instantiate(Objeto, transform.position, transform.rotation);
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }
    // debug

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadio);
        Gizmos.DrawWireSphere(transform.position, attackRadio);
    }
    void TakeDamage(int damage)
    {
        current.healthInicial -= damage;
        health = current.healthInicial;
        // mostrar vida
    }
}
