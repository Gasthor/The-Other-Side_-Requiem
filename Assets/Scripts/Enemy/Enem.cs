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

    GameObject player;
    Vector3 initialPosition;
    Rigidbody2D rb2d;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 target = initialPosition;
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
}
