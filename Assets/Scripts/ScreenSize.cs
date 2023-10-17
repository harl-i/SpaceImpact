using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    //[SerializeField] private int _width;
    //[SerializeField] private int _height;

    //private void Start()
    //{
    //    SetWindowSize(_width, _height);
    //}

    //private void SetWindowSize(int width, int height)
    //{
    //    Screen.SetResolution(width, height, false);
    //}

    void Start()
    {
        float targetAspect = 1920f / 1080f;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize / scaleHeight;
        }
    }
}
