using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public VectorValue p1;
    public VectorValue p2;

    private void Start()
    {
        
    }
    public void loadScene(string scene)
    {
        p1.inicial.x = -5;
        p1.inicial.y = 2.7f;
        p2.inicial.x = 6.8f;
        p2.inicial.y = 2.7f;
        SceneManager.LoadScene(scene);
        
    }
    public void SalirJuego()
    {
        Application.Quit();
    }


}
