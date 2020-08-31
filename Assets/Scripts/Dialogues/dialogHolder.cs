using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMan;
    [TextArea(3,10)]
    public string[] dialogueLines;
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "P1" || other.gameObject.name == "P2")
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                //dMan.ShowBox(dialogue);
                if (!dMan.dialogueActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            }
        }
        
    }
}
