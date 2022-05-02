using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Material mat;
    public Color[] myColors;
    int colorIndex = 0;
    float duration = 1.0f;
    float t = 0;

    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        mat.color = Color.Lerp(mat.color, myColors[colorIndex], lerp*Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerp * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= myColors.Length) ? 0 : colorIndex;
        }
    }
}
