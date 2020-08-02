using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restriccion : MonoBehaviour
{
    private List<string> lista;
    public string nom1;
    public string nom2;
    public string nom3;
    public string nom4;
    public string nom5;
    public string nom6;
    void Start()
    {
        lista = new List<string>();
        lista.Add(nom1);
        lista.Add(nom2);
        lista.Add(nom3);
        lista.Add(nom4);
        lista.Add(nom5);
        lista.Add(nom6);
    }

    // Update is called once per frame
    void Update()
    {
        int cont0 =0;
        int cont1 =0;
        for(int i = 0; i < 6; i++)
        {
            if (lista[i] != "0")
            {
                if (GameObject.Find(lista[i]) == null)
                {
                    cont1++;
                }
            }
            else
            {
                cont0++;
            }
        }
        if (cont1 + cont0 == 6)
        {
            Destroy(gameObject);
        }
    }
}
