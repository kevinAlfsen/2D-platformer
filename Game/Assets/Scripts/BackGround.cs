using UnityEngine;

public class BackGround : MonoBehaviour
{
    public int a, b;
    public float speed;
    float x, y;
    public float offsetX = 0, offsetY = 0;

    void Awake ()
    {
        
    }

    void Update ()
    {
        x = a * Mathf.Cos (Time.time * speed) + offsetX;
        y = b * Mathf.Sin (Time.time * speed) + offsetY;

        transform.position = new Vector3 (x, y, 10);
    }
}
