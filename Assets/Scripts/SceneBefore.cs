using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBefore : MonoBehaviour
{
    // Start is called before the first frame update
    public string escena;
    public VectorValue vectorP1;
    public VectorValue vectorP2;
    public Vector2 vector1;
    public Vector2 vector2;
    void Start()
    {
        
    }

    // Update is called once per frame


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")||collision.CompareTag("Player2"))
        {
            vectorP1.inicial = vector1;
            vectorP2.inicial = vector2;
            SceneManager.LoadScene(escena, LoadSceneMode.Single);
        }
    }

}
