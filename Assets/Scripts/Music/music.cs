using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private static music intance = null;
    public static music Instance
    {
        get { return intance; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (intance != null && intance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            intance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
