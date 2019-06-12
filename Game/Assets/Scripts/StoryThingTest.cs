using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryThingTest : MonoBehaviour
{
    public Player guttorm;
    public Ronny ronny;

    bool ronnyIsActive = false;

    void FixedUpdate ()
    {
        float distanceToGuttorm = (transform.position - guttorm.transform.position).magnitude;

        if (distanceToGuttorm < 2 && !ronnyIsActive)
        {
            ronny.gameObject.SetActive (true);
            Debug.Log ("Activated Ronny");
            ronnyIsActive = true;
        }
    }
}
