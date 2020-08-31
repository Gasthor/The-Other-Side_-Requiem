using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Player2") && !collision.CompareTag("MagiaEnemigo"))
        {

            if (collision.transform.tag == "Enemy")
            {
                collision.SendMessage("TakeDamage", damage);
            }
            Destroy(gameObject);
        }
    }
}
