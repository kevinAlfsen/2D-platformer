using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;

    void Awake ()
    {
        DontDestroyOnLoad (transform.gameObject);
    }

    void InitializeLevel (Scene level)
    {

    }

    int ticks = 0;

    void Update ()
    {
        double dieLimitY = -20.0;
        if (player.position.y < dieLimitY)
        {

        }
    }
    
}
