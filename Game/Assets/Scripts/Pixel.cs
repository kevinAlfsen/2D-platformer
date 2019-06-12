using UnityEngine;

public static class PixelMetrics
{
    public static Vector2[] neighbours = {
            new Vector2(-1, 1),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0),
            new Vector2(1, -1),
            new Vector2(0, -1),
            new Vector2(-1, -1),
            new Vector2(-1, 0)
        };

    /*
    public Vector2 position;
    public Vector2[] neighbours =
    {
        new Vector2(-1, 1),
        new Vector2(0, 1),
        new Vector2(1, 1),
        new Vector2(1, 0),
        new Vector2(1, -1),
        new Vector2(0, -1),
        new Vector2(-1, -1),
        new Vector2(-1, 0)
    };

    public Pixel (Vector2 _position)
    {
        position = _position;
    }

    public Vector2 topRight ()
    {
        return position + neighbours[0];
    } */
}
