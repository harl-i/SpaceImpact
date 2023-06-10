using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    private void Start()
    {
        SetWindowSize(_width, _height);
    }

    private void SetWindowSize(int width, int height)
    {
        Screen.SetResolution(width, height, false);
    }
}
