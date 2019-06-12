using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    Rigidbody2D rb;

    public float speed;

    public Transform[] moveTargets;
    public Transform currentTarget;
    public float moveTol;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        moveTargets = GetComponentsInChildren<Transform> ();

        StartCoroutine (MoveTo ());
    }

    void Jump (Vector2 direction)
    {
        rb.AddForce (direction * speed);
    }

    IEnumerator MoveTo ()
    {
        yield return new WaitForSeconds (2);
        for (int i = 1; i < moveTargets.Length; i++)
        {
            Transform moveTarget = moveTargets[i];
            currentTarget = moveTarget;

            while (Mathf.Abs (moveTarget.position.x - transform.position.x) > moveTol)
            {

                Vector2 direction;
                if (moveTarget.position.x < transform.position.x) //left
                    direction = new Vector2 (-1f, 2);
                else if (moveTarget.position.x > transform.position.x) //right
                    direction = new Vector2 (1f, 2);
                else
                    direction = Vector2.zero;

                
                
                Jump (direction);
                yield return new WaitForSeconds (2);
                Debug.Log ("Jumping");
                Debug.Log (Mathf.Abs (moveTarget.position.x - transform.position.x));
            }

            if (i == moveTargets.Length - 1)
                i = 1;
        }

        
    }



}
