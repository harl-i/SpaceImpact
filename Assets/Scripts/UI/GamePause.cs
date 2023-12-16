using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GamePause : MonoBehaviour
{
    [SerializeField] private Sprite _playIcon;
    [SerializeField] private Sprite _pauseIcon;

    private Image _buttonImage;
    private bool _isPaused = false;

    public static event Action<bool> OnPauseStateChanged;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void OnPauseButtonClick()
    {
        _isPaused = !_isPaused;
        OnPauseStateChanged?.Invoke(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;
        _buttonImage.sprite = _isPaused ? _pauseIcon : _playIcon;
    }
}
