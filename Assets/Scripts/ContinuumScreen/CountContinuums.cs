using TMPro;
using UnityEngine;

public class CountContinuums : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _continuumsCount;

    private void Start()
    {
        _continuumsCount.text = PlayerPrefs.GetInt(PlayerParameters.Continuum).ToString();
    }
}
