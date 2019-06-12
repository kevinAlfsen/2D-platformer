using UnityEditor;
using UnityEngine;

public class VisualizeTarget : MonoBehaviour
{
    public Enemy enemy;

    void OnDrawGizmos ()
    {
        Handles.color = Color.yellow;

        Handles.DrawWireDisc (transform.position, Vector3.back, enemy.moveTol);
    }
}
