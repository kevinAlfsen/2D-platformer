using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CheckPoint : MonoBehaviour
{
    Player player;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject.GetComponent<Player>();
            player.setCheckPoint (transform);
        }
    }
}
