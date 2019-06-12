using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            TriggerDialogue ();
        }
    }

}
