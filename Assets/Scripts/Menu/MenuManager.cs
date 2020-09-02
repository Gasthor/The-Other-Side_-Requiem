using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private void Start()
    {
        
    }
    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void SalirJuego()
    {
        Application.Quit();
    }


}
