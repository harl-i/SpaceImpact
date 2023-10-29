using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DominantColorFinder : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    private int _sampleCount = 30;

    [DllImport("__Internal")]
    private static extern void SetBackgroundColor(float r, float g, float b, float a);

    private void Start()
    {
        StartCoroutine(CaptureScreen());
    }

    private IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();

        Texture2D tex = new Texture2D(_cam.pixelWidth, _cam.pixelHeight, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, _cam.pixelWidth, _cam.pixelHeight), 0, 0);
        tex.Apply();

        Color dominantColor = GetDominantColor(tex);

#if !UNITY_EDITOR
        ChangeBackgroundColor(dominantColor);
#endif

        Debug.Log("Dominant color: " + dominantColor);
    }

    private Color GetDominantColor(Texture2D tex)
    {
        Dictionary<Color, int> colorFrequency = new Dictionary<Color, int>();

        for (int i = 0; i < _sampleCount; i++)
        {
            int x = Random.Range(0, tex.width);
            int y = Random.Range(0, tex.height);

            Color pixelColor = tex.GetPixel(x, y);

            if (colorFrequency.ContainsKey(pixelColor))
            {
                colorFrequency[pixelColor]++;
            }
            else
            {
                colorFrequency.Add(pixelColor, 1);
            }
        }

        Color dominantColor = Color.black;
        int maxFrequency = 0;

        foreach (var color in colorFrequency)
        {
            if (color.Value > maxFrequency)
            {
                maxFrequency = color.Value;
                dominantColor = color.Key;
            }
        }

        return dominantColor;
    }

    public void ChangeBackgroundColor(Color color)
    {
        SetBackgroundColor(color.r, color.g, color.b, color.a);
    }
}
