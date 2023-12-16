using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SoundSwitch : MonoBehaviour
{
    [SerializeField] private Sprite _soundOnIcon;
    [SerializeField] private Sprite _soundOffIcon;

    private Image _buttonImage;
    private bool _isSoundOn;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    private void Start()
    {
        LoadSoundState();
    }

    public void ToggleSound()
    {
        _isSoundOn = !_isSoundOn;
        SaveSoundState();

        if (_isSoundOn)
        {
            _buttonImage.sprite = _soundOnIcon;
            AudioListener.volume = 1;
        }
        else
        {
            _buttonImage.sprite = _soundOffIcon;
            AudioListener.volume = 0;
        }
    }

    public void SaveSoundState()
    {
        PlayerPrefs.SetInt("isSoundOn", _isSoundOn ? 1 : 0);
    }

    public void LoadSoundState()
    {
        _isSoundOn = PlayerPrefs.GetInt("isSoundOn", 1) == 1;
        if (_isSoundOn)
        {
            _buttonImage.sprite = _soundOnIcon;
        }
        else
        {
            _buttonImage.sprite = _soundOffIcon;
        }
    }
}
