using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBefore : MonoBehaviour
{
    // Start is called before the first frame update
    public string escena;
    public VectorValue vectorI;
    public Vector2 vector;
    void Start()
    {
        
    }

    // Update is called once per frame


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            vectorI.inicial = vector;
            SceneManager.LoadScene(escena, LoadSceneMode.Single);
        }
    }

}
