using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite _sprite1;
    [SerializeField] private Sprite _sprite2;
    private Image _buttonImage;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _buttonImage = _button.GetComponent<Image>();
    }

    public void SwitchSprite()
    {
        if (_buttonImage.sprite == _sprite1)
        {
            _buttonImage.sprite = _sprite2;
        }
        else
        {
            _buttonImage.sprite = _sprite1;
        }
    }
}