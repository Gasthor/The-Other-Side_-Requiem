using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Inicio");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
