
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    bool isCharging = false;

    public float minForceY, minForceX, maxForceY, maxForceX;
    public float speed;

    Vector2 chargeStartPosition, chargeStopPosition;

    Rigidbody2D rb;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void OnMouseDown ()
    {
        if (!isCharging && isGrounded ())
        {
            Charge ();
        }
            
    }

    void OnMouseUp ()
    {
        if (isCharging && isGrounded ())
        {
            Jump ();
        }
            
    }

    void Jump ()
    {
        chargeStopPosition = Input.mousePosition;
        isCharging = false;

        Vector2 moveDirection = Vector2.zero;

        if (chargeStopPosition.x > chargeStartPosition.x) //Right
            moveDirection.x = Mathf.Abs (chargeStopPosition.x - chargeStartPosition.x);
        if (chargeStopPosition.x < chargeStartPosition.x) //Left
            moveDirection.x = -Mathf.Abs (chargeStartPosition.x - chargeStopPosition.x);
        if (chargeStopPosition.y > chargeStartPosition.y) //up
            moveDirection.y = (Mathf.Abs (chargeStopPosition.y - chargeStartPosition.y));
        if (chargeStopPosition.y < chargeStartPosition.y) //down
            moveDirection.y = -Mathf.Abs (chargeStartPosition.y - chargeStopPosition.y);

        Vector2 force = new Vector2(
            Mathf.Clamp(moveDirection.x * speed, minForceX, maxForceX),
            Mathf.Clamp(moveDirection.y * speed, minForceY, maxForceY)
            );

        Debug.Log ("Added " + force.ToString () + "force");
        rb.AddForce (force);
    }

    void Charge ()
    {
        isCharging = true;
        chargeStartPosition = Input.mousePosition;
    }

    bool isGrounded ()
    {
        return true;
    }

    /*
    Rigidbody2D rb;
    Collider2D col;

    bool chargingToss;
    //bool isGrounded = true;
    Vector2 chargeStartPos, chargeStopPos;

    public float speed = 50;
    public float maxForceX, maxForceY;
    public float groundedRayDistance;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        col = GetComponent<Collider2D>();
    }

    void OnMouseDown ()
    {
        if (!chargingToss && isGrounded())
        {
            chargeStartPos = Input.mousePosition;
            chargingToss = true;
        }
    }

    void OnMouseUp ()
    {
        if (chargingToss)
        {
            chargeStopPos = Input.mousePosition;
            chargingToss = false;

            TossPlayer ();
        }
        
    }

    void TossPlayer ()
    {
        Vector2 moveDirection = Vector2.zero;

        if (chargeStopPos.x > chargeStartPos.x) //Right
            moveDirection.x = Mathf.Abs (chargeStopPos.x - chargeStartPos.x);
        if (chargeStopPos.x < chargeStartPos.x) //Left
            moveDirection.x = -Mathf.Abs (chargeStartPos.x - chargeStopPos.x);
        if (chargeStopPos.y > chargeStartPos.y) //up
            moveDirection.y = (Mathf.Abs (chargeStopPos.y - chargeStartPos.y)) * 2;
        if (chargeStopPos.y < chargeStartPos.y) //down
            moveDirection.y = -Mathf.Abs (chargeStartPos.y - chargeStopPos.y);

        if (Mathf.Abs (moveDirection.x) > maxForceX)
        {
            Debug.Log ("Restricted X force down from :" + moveDirection.x);
            moveDirection.x = maxForceX * (moveDirection.x / Mathf.Abs(moveDirection.x));
        }

        if (Mathf.Abs (moveDirection.y) > maxForceY)
        {
            Debug.Log ("Restricted Y force down from :" + moveDirection.y);
            moveDirection.y = maxForceY * (moveDirection.y / Mathf.Abs(moveDirection.y));
        }
            
        Vector2 force = moveDirection * speed;
        rb.AddForce (force);
    }

    bool isGrounded ()
    {
        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y - col.bounds.extents.y - 0.1f);
        Vector2 rayEnd = new Vector2 (transform.position.x, transform.position.y - col.bounds.extents.y - 1f);

        RaycastHit2D hit = Physics2D.Linecast (rayStart, rayEnd);
        Debug.DrawLine (rayStart, rayEnd, Color.blue, 2f);

        if (hit.collider != null)
        {
            Debug.Log (hit.collider.transform.name);
            return true;
        } else
        {
            return false;
        }
    }
    */

}

