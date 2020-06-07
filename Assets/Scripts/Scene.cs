using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public string escena;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(escena,LoadSceneMode.Single);
            }
    }
    
}
