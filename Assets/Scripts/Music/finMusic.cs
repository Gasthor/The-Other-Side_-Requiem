using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (music.Instance)
        {
            Destroy(music.Instance.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
