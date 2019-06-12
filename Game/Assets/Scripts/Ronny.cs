using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronny : Enemy
{
    public Dialogue[] dialogues;

    DialogueManager dialogueManager;
    Player guttorm;

    public void StopMoving ()
    {
        CancelInvoke ();
    }

    public void StartMoving ()
    {
        InvokeRepeating ("CheckForJump", 1.0f, 1.0f);
    }

    void Start ()
    {
        guttorm = FindObjectOfType<Player> ();
        dialogueManager = FindObjectOfType<DialogueManager> ();
        InvokeRepeating ("CheckForDialogueOne", 0.5f, 0.5f);
    }

    void CheckForDialogueOne ()
    {
        if ((guttorm.transform.position - transform.position).magnitude < 2)
        {
            CancelInvoke ();
            dialogueManager.StartDialogue (dialogues[0]);
            WaitForDialogueEnd ();
            StartMoving ();
        }
    }

    IEnumerator WaitForDialogueEnd ()
    {
        yield return new WaitUntil (() => dialogueManager.dialogueEnded == true);
    }
}
