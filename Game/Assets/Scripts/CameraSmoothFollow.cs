using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform target;

    public float smoothAmount = 0.125f;
    public Vector3 offset;

    void FixedUpdate ()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothAmount);
        transform.position = smoothedPosition;
    }
}
