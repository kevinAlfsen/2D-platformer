using UnityEngine;

public class Player : MonoBehaviour {

    //Variables set in inspector
    public float yDeathLimit = -4;

    //Inaccessible variables
    Vector2 startPosition;
    Transform checkPoint;
    Rigidbody2D rb;

    void Awake ()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D> ();

        InvokeRepeating ("checkForFallenOff", 1.0f, 1.0f);
    }

    public void setCheckPoint (Transform _checkPoint)
    {
        checkPoint = _checkPoint;
    }

    void checkForFallenOff ()
    {
        if (transform.position.y < yDeathLimit)
        {
            rb.velocity = Vector2.zero;
            rb.rotation = 0;
            if (checkPoint != null)
                transform.position = checkPoint.position;
            else
                transform.position = startPosition;
        }
    }
}
