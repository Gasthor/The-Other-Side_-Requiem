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

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();//NUEVO
    }
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
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
        thePlayer.canMove = false;//NUEVO
    }
}
