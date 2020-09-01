using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class HealthScore : MonoBehaviour
{
    public int heal;
    public int individual;
    public ContadorAlmas almas;
    private GameObject p1;
    private GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("P1");
        p2 = GameObject.Find("P2");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            p1.SendMessage("Health", heal);
            p2.SendMessage("Health", heal);
            almas.contador = almas.contador+individual;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
