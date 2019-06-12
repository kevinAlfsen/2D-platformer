using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float xBoundary, yBoundary;

    void LateUpdate ()
    {

        Vector3 moveDirection = transform.position;

        if (Mathf.Abs(transform.position.x - target.position.x) > xBoundary)
        {
            moveDirection.x = target.position.x - xBoundary;
        }
        if (transform.position.y - target.position.y > yBoundary)
        {
            moveDirection.y = target.position.y + yBoundary;
        }

        transform.position = moveDirection;

    }
}
