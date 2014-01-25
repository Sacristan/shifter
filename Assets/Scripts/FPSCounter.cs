using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{

    private float fps;
    public Color color;

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 25, 0, 50, 50), fps.ToString());
    }

    void Update()
    {
        fps = Mathf.RoundToInt((1.0f / Time.smoothDeltaTime) * 100) / 100;
    }
}
