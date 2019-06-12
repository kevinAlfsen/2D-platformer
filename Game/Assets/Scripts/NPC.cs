using UnityEngine;

public class NPC : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float moveTol;

    Transform target;

    Vector2 currentPosition;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void CheckForLanding ()
    {
        if (hasLanded ())
        {
            CancelInvoke ("CheckForLanding");
        }
    }

    void CheckForMovement ()
    {
        if (hasMoved ())
        {
            CancelInvoke ("CheckForMovement");
        }
    }

    void Jump ()
    {
        Vector2 direction;

        if (target.position.x < transform.position.x)
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
        float distanceToTarget = Mathf.Abs (transform.position.x - target.position.x);

        if (distanceToTarget > moveTol)
            return true;
        else
            return false;
    }

}
