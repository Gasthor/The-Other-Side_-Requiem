using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicaBoss : MonoBehaviour
{
    public bool panel = false;
    public GameObject pausaMenu;
    public Player Player1;
    public Player2Movement Player2;
    public AudioSource musica;

    private void Start()
    {

        Player1 = FindObjectOfType<Player>();
        Player2 = FindObjectOfType<Player2Movement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel)
            {
                Resumen();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        musica.Pause();
        

        Player1.canMove = false;
        Player2.canMove = false;
        pausaMenu.SetActive(true);
        Time.timeScale = 0f;
        panel = true;
    }
    public void Resumen()
    {
        musica.Play();
        

        Player1.canMove = true;
        Player2.canMove = true;
        pausaMenu.SetActive(false);
        Time.timeScale = 1f;
        panel = false;
    }
    public void Inicio(string scene)
    {
        Resumen();
        SceneManager.LoadScene(scene);
    }
}


