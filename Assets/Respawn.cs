using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public string escena;
    public HealthSystem healthBarP1;
    public HealthSystem healthBarP2;
    public VectorValue vectorP1;
    public VectorValue vectorP2;
    public Vector2 vector1;
    public Vector2 vector2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarP1.healthInicial <= 0 && healthBarP2.healthInicial <= 0)
        {

            vectorP1.inicial = vector1;
            vectorP2.inicial = vector2;
            healthBarP1.healthInicial = 100;
            healthBarP2.healthInicial = 100;
            SceneManager.LoadScene(escena, LoadSceneMode.Single);
        }
    }
}
