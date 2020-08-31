using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public bool pausa = false;
    public GameObject pauseMenu;
    public Player P1;
    public Player2Movement P2;
    private AudioSource fondo;

    private void Start()
    {
        if (music.Instance)
        {
            fondo = music.Instance.gameObject.GetComponent<AudioSource>();
        }
        
        P1 = FindObjectOfType<Player>();
        P2 = FindObjectOfType<Player2Movement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (music.Instance)
        {
            fondo.Pause();
        }

        P1.canMove = false;
        P2.canMove = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }
    public void Resume()
    {
        if (music.Instance)
        {
            fondo.Play();
        }
        
        P1.canMove = true;
        P2.canMove = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }
    public void Inicio(string scene)
    {
        Resume();
        if (music.Instance)
        {
            Destroy(music.Instance.gameObject);
        }
        SceneManager.LoadScene(scene);
    }
}
