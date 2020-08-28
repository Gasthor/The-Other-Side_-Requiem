using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Almas : MonoBehaviour
{
    public ContadorAlmas scoreAmount;
    private Text scoreText;
    private void Start()
    {

        scoreText = GetComponent<Text>();
    }
    private void Update()
    {
        scoreText.text = "Almas: " + scoreAmount.contador;
    }
}
