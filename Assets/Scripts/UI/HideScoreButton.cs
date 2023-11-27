using UnityEngine;
using UnityEngine.UI;

public class HideScoreButton : MonoBehaviour
{
    [SerializeField] private Button _scoreButton;

    public void Hide()
    {
        _scoreButton.gameObject.SetActive(false);
    }
}
