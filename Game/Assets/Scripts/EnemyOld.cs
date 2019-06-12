using UnityEngine;

public class EnemyOld : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 7000;
    public float moveTol = 2;

    float distanceToTarget = 0;
    public Transform target;
    Vector2 direction;
    Vector2 currentPosition;

    Transform[] foundTargets;
    public Transform[] targets;
    public int targetIndex = 0;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();

        /*
        foundTargets = GetComponentsInChildren<Transform> ();
        targets = new Transform[foundTargets.Length - 1];

        int index = 0;
        foreach (Transform target in foundTargets)
        {
            if (target.tag == "moveTarget")
            {
                targets[index++] = target;
            }
        } */

        ChangeTarget ();
    }

    void Start ()
    {
        if (shouldJump ())
        {
            Invoke ("Jump", 2.0f);
        } else
        {
            InvokeRepeating ("CheckForMovement", 3.0f, 3.0f);
        }
    }

    bool shouldJump ()
    {
        distanceToTarget = Mathf.Abs (transform.position.x - target.position.x);
        if (distanceToTarget > moveTol)
        {
            return true;
        } else
        {
            ChangeTarget ();
            return true;

            /*
            ChangeTarget ();
            distanceToTarget = Mathf.Abs (transform.position.x - target.position.x);
            if (distanceToTarget > moveTol)
            {
                return true;
            } else
            {
                return false;
            }*/
        }
    }

    void Jump ()
    {
        if (target.position.x < transform.position.x)
        {
            direction = new Vector2 (-1, 2);
        } else if (target.position.x > transform.position.x)
        {
            direction = new Vector2 (1, 2);
        }


        Vector2 force = direction * speed;
        rb.AddForce (force);

        InvokeRepeating ("CheckForLanding", 3.0f, 3.0f);
    }

    bool HasMoved ()
    {
        if (new Vector2 (transform.position.x, transform.position.y) == currentPosition)
        {
            return false;
        } else
        {
            currentPosition = transform.position;
            return true;
        }
    }

    bool HasLanded ()
    {
        if (Mathf.Abs (rb.velocity.y) < 0.1f)
        {
            Debug.Log (rb.velocity.y);
            return true;
        } else
        {
            Debug.Log (rb.velocity.y.ToString () + "is too high to have landed");
            return false;
        }
    }

    void CheckForMovement ()
    {
        Debug.Log ("Checking for movement...");
        if (HasMoved ())
        {
            Debug.Log ("I moved");
            if (shouldJump ())
            {
                CancelInvoke ("CheckForMovement");
                Jump ();
            }

        }
    }

    void CheckForLanding ()
    {
        if (HasLanded ())
        {
            CancelInvoke ("CheckForLanding");
            if (shouldJump ())
            {
                Jump ();
            } else
            {
                currentPosition = transform.position;
                InvokeRepeating ("CheckForMovement", 3.0f, 3.0f);
            }
        }
        /*
        if (HasLanded () && shouldJump ())
        {
            Debug.Log ("Landed and jumping");
            CancelInvoke ("CheckForLanding");
            Jump ();
        } else
        {
            Debug.Log ("Waiting for landing...");
        }*/
    }

    void ChangeTarget ()
    {
        target = targets[targetIndex++];
        if (targetIndex >= targets.Length)
        {
            targetIndex = 0;
        }
    }
}
