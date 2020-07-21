using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;

    [TextArea(3,10)]
    public string[] dialogLines;


    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();    
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "P1" || other.gameObject.name == "P2")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                //dMan.ShowBox(dialogue);
                if (!dMan.dialogueActive)
                {
                    dMan.dialogLines = dialogLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            }
        }
    }
}
