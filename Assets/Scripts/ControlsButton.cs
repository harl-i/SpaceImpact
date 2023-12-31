using System.Collections;
using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    [SerializeField] private GameObject _mobileControls;
    [SerializeField] private GameObject _pcControls;
    [SerializeField] private float _delay;
    
    private GameObject _controlsScreen;

    private void Awake()
    {
#if UNITY_EDITOR
        _controlsScreen = _pcControls;
#endif
    }

    public void SwitchControlMethodBasedOnPlatform(int isMobileNumber)
    {
#if !UNITY_EDITOR
        if (isMobileNumber == 1)
        {
            _controlsScreen = _mobileControls;
        }
        else
        {
            _controlsScreen = _pcControls;
        }
#endif
    }

    public void OpenControlsScreen()
    {
        StartCoroutine(OpenWithDelay());
    }

    private IEnumerator OpenWithDelay()
    {
        yield return new WaitForSeconds(_delay);
        _controlsScreen.SetActive(true);
    }
}
