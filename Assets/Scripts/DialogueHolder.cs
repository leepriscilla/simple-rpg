using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialog;
    public string[] dialogLines;

    private DialogueManager dMan;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                //dMan.ShowBox(dialog);
                if(!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialog();
                }
            }
        }
    }
}
