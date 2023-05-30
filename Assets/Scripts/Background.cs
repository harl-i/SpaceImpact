using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Background : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionX;
    private float _speed—oefficient = 100f;
    private float _maxPositionX = 1f;
    private float _imagePositionY = 0;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += (_speed / _speed—oefficient) * Time.deltaTime;

        if (_imagePositionX > _maxPositionX)
        {
            _imagePositionX = 0;
        }

        _image.uvRect = new Rect(_imagePositionX, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }
}
