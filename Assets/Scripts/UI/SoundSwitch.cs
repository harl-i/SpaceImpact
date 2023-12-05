using UnityEngine;
using UnityEngine.UI;

public class SoundSwitch : MonoBehaviour
{
    //public AudioSource audioSource;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    private Image buttonImage;
    private bool isSoundOn;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        LoadSoundState();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        SaveSoundState();

        if (isSoundOn)
        {
            buttonImage.sprite = soundOnIcon;
            //audioSource.Play(); // Включить звук
            AudioListener.volume = 1;
        }
        else
        {
            buttonImage.sprite = soundOffIcon;
            //audioSource.Stop(); // Выключить звук
            AudioListener.volume = 0;
        }
    }

    public void SaveSoundState()
    {
        PlayerPrefs.SetInt("isSoundOn", isSoundOn ? 1 : 0);
    }

    public void LoadSoundState()
    {
        isSoundOn = PlayerPrefs.GetInt("isSoundOn", 1) == 1;
        if (isSoundOn)
        {
            buttonImage.sprite = soundOnIcon;
        }
        else
        {
            buttonImage.sprite = soundOffIcon;
        }
    }
}
