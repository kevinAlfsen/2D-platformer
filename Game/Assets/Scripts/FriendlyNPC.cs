using UnityEngine;

public class FriendlyNPC : MonoBehaviour
{
    public float speed;
    public float moveTol;
    public float resetTol;
    public Transform[] targets;

    public Rigidbody2D rb;
    Vector2 currentPosition;
    public Vector3 startPosition;

    Transform target;
    Vector2 targetPosition;
    int targetIndex = 0;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        startPosition = transform.position;
        targetPosition = startPosition;
        Move ();
    }

    void Move ()
    {
        if (shouldJump ())
        {
            Jump ();
            InvokeRepeating ("CheckForLanding", 2.0f, 2.0f);
        } else
        {
            InvokeRepeating ("CheckForMovement", 2.0f, 2.0f);
        }
    }

    void ChangeTarget ()
    {
        if (targetIndex >= targets.Length)
            targetIndex = 0;

        target = targets[targetIndex++];
        targetPosition = target.position;
    }

    void CheckForLanding ()
    {
        Debug.Log ("CheckedForLanding");
        if (shouldReset ())
            Reset ();

        if (hasLanded ())
        {
            CancelInvoke ("CheckForLanding");
            Move ();
        }
    }

    void CheckForMovement ()
    {
        Debug.Log ("CheckedForMovement");
        if (shouldReset ())
            Reset ();

        if (hasMoved ())
        {
            CancelInvoke ("CheckForMovement");
            Move ();
        }
    }

    void Jump ()
    {
        Vector2 direction;

        if (targetPosition.x < transform.position.x)
        {
            direction = new Vector2 (-1, 2);
        } else
        {
            direction = new Vector2 (1, 2);
        }


        Vector2 force = direction * speed;
        rb.AddForce (force);
    }

    bool hasMoved ()
    {
        Vector2 position = new Vector2 (transform.position.x, transform.position.y);

        if (position == currentPosition)
            return false;
        else
            return true;
    }

    bool hasLanded ()
    {
        if (Mathf.Abs (rb.velocity.y) < 1)
            return true;
        else
            return false;
    }

    bool shouldJump ()
    {
        float distanceToTarget = Mathf.Abs (transform.position.x - targetPosition.x);

        if (distanceToTarget > moveTol)
            return true;
        else
            return false;
    }

    bool shouldReset ()
    {
        float yDistanceToTarget = Mathf.Abs (transform.position.y - targetPosition.y);

        if (yDistanceToTarget > resetTol)
            return true;
        else
            return false;
    }

    public virtual void Reset ()
    {
        rb.velocity = Vector2.zero;
        rb.rotation = 0;

        transform.position = startPosition;
        CancelInvoke ();
    }
}