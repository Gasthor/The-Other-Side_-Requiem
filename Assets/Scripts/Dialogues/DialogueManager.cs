using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dbox;
    public Text dText;

    public bool dialogueActive;
    [TextArea(3, 10)]
    public string[] dialogLines;
    public int currentLine;

    private Player thePlayer; //NUEVO
    private Player2Movement thePlayer2;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();//NUEVO
        thePlayer2 = FindObjectOfType<Player2Movement>();
    }
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Q))
        {
            //dbox.SetActive(false);
            //dialogueActive = false;
            currentLine++;
        }
        if(currentLine >= dialogLines.Length)
        {
            dbox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
            thePlayer.canMove = true;//NUEVO
            thePlayer2.canMove = true;
        }

        dText.text = dialogLines[currentLine];
        
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dbox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dbox.SetActive(true);
        thePlayer.canMove = false;
        thePlayer2.canMove = false;
    }
}
