using UnityEngine;

public class ScoreUpdateHandler : MonoBehaviour
{
    [SerializeField] private GameObject _windowSuccess;
    [SerializeField] private GameObject _windowFailure;
    [SerializeField] private GameObject _windowError;

    public void OnScoreUpdatedSuccessfully()
    {
        _windowSuccess.SetActive(true);
    }

    public void OnScoreUpdateFailed()
    {
        _windowFailure.SetActive(true);
    }

    public void OnScoreUpdateError()
    {
        _windowError.SetActive(true);
    }
}
