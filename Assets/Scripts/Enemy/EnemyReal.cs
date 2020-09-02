using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReal : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    private Transform target;

    public Transform homePos;
    public GameObject Objeto;
    public GameObject corazon;
    public Indicador indicador;
    bool attacking;
    public float attackSpeed;

    public float speed;
    public float MaxRange;
    public float minRange;

    public int health;
    public HealthSystem current;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        health = current.healthInicial;

        if (current.healthInicial <= 0)
        {
            Destroy(gameObject);
        }
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 target1 = homePos.position;
        if (current.healthInicial <= 0)
        {
            Heart();
            Destroy(gameObject);
        }

        if (Vector3.Distance(player.transform.position, transform.position) <= Vector3.Distance(player2.transform.position, transform.position))
        {
            //int health1 = player.GetComponent<Player>().currentHealth;
            if (player.GetComponent<Player>().healthInicial.healthInicial > 0)
            {
                target = player.transform;
                indicador.indicador = 1;
            }
            else
            {
                target = player2.transform;
                indicador.indicador = 2;
            }
        }
        else
        {
            if (player2.GetComponent<Player2Movement>().healthInicial.healthInicial > 0)
            {
                target = player2.transform;
                indicador.indicador = 2;
            }
            else
            {
                target = player.transform;
                indicador.indicador = 1;
            }
        }
        //Animacion
        float distance = Vector3.Distance(homePos.position, transform.position);
        Vector3 dir = (target.position - transform.position).normalized;
        if (homePos.position != target1 && distance < minRange)
        {
            anim.SetFloat("moveX", dir.x);
            anim.SetFloat("moveY", dir.y);
            anim.Play("EnemyWalk", -1, 0);
            anim.SetBool("moving", false);
        }
        else
        {
            anim.speed = 1;
            anim.SetFloat("moveX", dir.x);
            anim.SetFloat("moveY", dir.y);
            anim.SetBool("moving", true);
        }
        if (target1 == homePos.position && distance < 0.02f)
        {
            anim.SetBool("moving", false);
        }
        //
        if (Vector3.Distance(target.position, transform.position) <= MaxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();

        }
        else if (Vector3.Distance(target.position, transform.position) >= MaxRange)
        {
            GoHome();
        }
        if (Vector3.Distance(target.position, transform.position) <= minRange)
        {
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }


    }
    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
    }
    public void Heart()
    {
        Instantiate(corazon, transform.position, transform.rotation);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MaxRange);
        Gizmos.DrawWireSphere(transform.position, minRange);
    }
    void TakeDamage(int damage)
    {
        current.healthInicial -= damage;
        health = current.healthInicial;
        // mostrar vida
    }
    IEnumerator Attack(float seconds)
    {
        attacking = true;
        if (Objeto != null)
        {
            Instantiate(Objeto, transform.position, transform.rotation);
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }
    void OnGUI()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        int health = current.healthInicial;
        GUI.Box(
            new Rect(
                pos.x - 20,
                Screen.height - pos.y - 110,
                45,
                30), "" + health
            );
    }
}