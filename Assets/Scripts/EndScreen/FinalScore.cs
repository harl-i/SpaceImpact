using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private void Start()
    {
        _score.text = PlayerPrefs.GetInt(PlayerParameters.Score).ToString();
    }
}
