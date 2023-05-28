using System.Collections;
using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    [SerializeField] private GameObject _controlsScreen;
    [SerializeField] private float _delay;

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
