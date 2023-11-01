using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    private bool _isMuted = false;

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        AudioListener.volume = _isMuted ? 0 : 1;
    }
}
