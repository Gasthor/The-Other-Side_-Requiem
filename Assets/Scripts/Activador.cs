using UnityEngine;

public class Activador : MonoBehaviour
{
    public string boss;
    public GameObject escena;
    void Start()
    {
        escena.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(boss) == null)
        {
            escena.SetActive(true);
        }
    }
}
