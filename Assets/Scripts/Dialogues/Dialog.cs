using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    public bool isDialogueActive;
    Coroutine auxCorutine;

    public bool player1InRange;
    public bool player2InRange;



    // Start is called before the first frame update
    void Start()
    {

    }
    public void AbrirCajaDialogo(int valor)
    {
        if (isDialogueActive)
        {
            CerrarDialogo();
            StartCoroutine(esperaDesaparicionDialogo(valor));
        }
        else
        {
            isDialogueActive = false;
            auxCorutine = StartCoroutine(mostrarDialogo(valor));
        }
    }

    IEnumerator mostrarDialogo(int valor, float time = 0.0000001f)
    {
        dialogBox.SetActive(true);
        string[] dialogo;
        dialogo = dialog;

        int total = dialogo.Length;
        string res = "";
        isDialogueActive = true;
        yield return null;
        for (int i = 0; i < total; i++)
        {
            res = "";
            if (isDialogueActive)
            {
                for (int j = 0; j < dialogo[i].Length; j++)
                {
                    if (isDialogueActive)
                    {
                        res = string.Concat(res, dialogo[i][j]);
                        dialogText.text = res;
                        yield return new WaitForSeconds(time);
                    }
                    else yield break;
                }
                yield return new WaitForSeconds(1);
            }
            else yield break;
        }
        yield return new WaitForSeconds(1);
        CerrarDialogo();
    }

    IEnumerator esperaDesaparicionDialogo(int valor)
    {
        yield return new WaitForEndOfFrame();
        auxCorutine = StartCoroutine(mostrarDialogo(valor));
    }

    public void CerrarDialogo()
    {
        isDialogueActive = false;
        if (auxCorutine != null)
        {
            StopCoroutine(auxCorutine);
            auxCorutine = null;
        }

        dialogText.text = "";
        dialogBox.SetActive(false);
    }
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player1InRange = true;
        }
        if (other.CompareTag("Player2"))
        {
            player2InRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player1InRange = false;
            dialogBox.SetActive(false);
        }
        if (other.CompareTag("Player2"))
        {
            player2InRange = false;
            dialogBox.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player1InRange)
        {
            AbrirCajaDialogo(0);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && player2InRange)
        {
            AbrirCajaDialogo(0);
        }

    }
}
