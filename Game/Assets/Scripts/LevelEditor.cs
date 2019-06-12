using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour {

    public Texture2D map;

    Color thisPixel;
    Color previousPixel;
    List<Vector2> path;
    PolygonCollider2D polyCol;

    void Awake ()
    {
        polyCol = GetComponent<PolygonCollider2D> ();
        path = new List<Vector2> ();
    }

    void Start ()
    {
        CheckPixels ();
        polyCol.SetPath (0, path.ToArray());
    }

    void CheckPixels ()
    {
        for (int y = 0; y < map.height; y++)
        {
            for (int x = 0; x < map.width; x++)
            {
                CheckPixel (x, y);
            }
        }
    }

    void CheckPixel (int x, int y)
    {
        Vector2 position = new Vector2 (x, y);

        thisPixel = map.GetPixel ((int)position.x, (int)position.y);
        Color topLeftPixel = getPixel (position, 0);
        Color topRightPixel = getPixel (position, 2);
        Color bottomRightPixel = getPixel (position, 4);
        Color bottomLeftPixel = getPixel (position, 6);
        Color topPixel = getPixel (position, 1);
        Color rightPixel = getPixel (position, 3);
        Color bottomPixel = getPixel (position, 5);
        Color leftPixel = getPixel (position, 7);

        if (thisPixel.a == 0)
        {
            if (topLeftPixel.a == 0)
            {
                if ((leftPixel.a == 0 && topPixel.a == 0) || (leftPixel.a != 0 && topPixel.a != 0))
                {

                    path.Add (new Vector2 (x - 0.25f, y + 0.25f));
                }
            }

            if (topRightPixel.a == 0)
            {
                if ((leftPixel.a == 0 && topPixel.a == 0) || (leftPixel.a != 0 && topPixel.a != 0))
                {
                    path.Add (new Vector2 (x + 0.25f, y + 0.25f));
                }
            }

            if (bottomRightPixel.a == 0)
            {
                if ((leftPixel.a == 0 && topPixel.a == 0) || (leftPixel.a != 0 && topPixel.a != 0))
                {
                    path.Add (new Vector2 (x + 0.25f, y - 0.25f));
                }
            }

            if (bottomLeftPixel.a == 0)
            {
                if ((leftPixel.a == 0 && topPixel.a == 0) || (leftPixel.a != 0 && topPixel.a != 0))
                {
                    path.Add (new Vector2 (x - 0.25f, y - 0.25f));
                }
            }
        }
    }

    Color getPixel (Vector2 position, int i)
    {
        Vector2 newPosition = position + PixelMetrics.neighbours[i];
        return map.GetPixel ((int)newPosition.x, (int)newPosition.y);
    }
}
