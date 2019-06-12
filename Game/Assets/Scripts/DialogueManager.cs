using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;
    public Image dialogueBox;
    public Text mainText;
    public Text title;
    public Image dialogueImage;

    public bool dialogueEnded = false;

	void Start () {
        sentences = new Queue<string> ();
	}

    public void StartDialogue (Dialogue dialogue)
    {
        dialogueBox.gameObject.SetActive (true);

        Debug.Log ("Starting dialogue with : " + dialogue.title);

        sentences.Clear ();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }

        title.text = dialogue.title;
        dialogueImage.sprite = dialogue.sprite;
        dialogueEnded = false;
        DisplayNextSentence ();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue ();
            return;
        }

        string sentence = sentences.Dequeue ();
        mainText.text = sentence;
    }

    void EndDialogue ()
    {
        dialogueEnded = true;
        dialogueBox.gameObject.SetActive (false);
        Debug.Log ("Dialogue ended");
    }

    public void buttonClicked ()
    {
        Debug.Log ("Button was clicked");
    }
}
