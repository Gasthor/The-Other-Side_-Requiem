using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        music.Instance.gameObject.GetComponent<AudioSource>().Stop();
        music.Instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
