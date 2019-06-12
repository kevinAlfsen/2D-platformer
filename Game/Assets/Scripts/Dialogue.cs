using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    
    public string title;
    public Sprite sprite;
    [TextArea (0, 22)]
    public string[] sentences;

}
