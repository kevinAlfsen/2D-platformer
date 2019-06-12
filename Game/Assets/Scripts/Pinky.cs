using System.Collections;
using UnityEngine;

public class Pinky : FriendlyNPC
{

    public Player guttorm;

    DialogueManager dialogueManager;
    public Dialogue[] dialogues;

    bool dialogue1HasFired = false;
    bool dialogue2HasFired = false;

    void Start ()
    {
        dialogueManager = FindObjectOfType<DialogueManager> ();
        InvokeRepeating ("Dialogue1Check", 1.0f, 0.5f);
    }

    public override void Reset ()
    {
        if (!dialogue1HasFired)
        {
            dialogueManager.StartDialogue (dialogues[0]);
            dialogue1HasFired = true;
        }

        rb.velocity = Vector2.zero;
        rb.rotation = 0;

        transform.position = startPosition;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (!dialogue2HasFired && col.transform.tag == "Player")
        {
            dialogueManager.StartDialogue (dialogues[1]);
            dialogue2HasFired = true;
        }
    }

    void Dialogue1Check ()
    {
        float distanceToGuttorm = (transform.position - guttorm.transform.position).magnitude;

        if (distanceToGuttorm < 5 && !dialogue1HasFired)
        {
            dialogue1HasFired = true;
            dialogueManager.StartDialogue (dialogues[0]);
            CancelInvoke ("Dialogue1Check");
            StartCoroutine ("WaitForDialogueEnd");

        }
    }

    IEnumerator WaitForDialogueEnd ()
    {
        yield return new WaitUntil (() => dialogueManager.dialogueEnded == true);
        yield return new WaitForSeconds (1f);
        rb.AddForce (new Vector2 (0, 1) * 7000);
        yield return new WaitForSeconds (1f);
        dialogueManager.StartDialogue (dialogues[1]);
    }
}
