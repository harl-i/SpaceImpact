using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private SaveLoadSystem _saveLoadSystem;

    private void Awake()
    {
        _saveLoadSystem = new SaveLoadSystem(Application.persistentDataPath + "/save.json");
    }

    private void Start()
    {
        PlayerData playerData = _saveLoadSystem.Load();

        if (playerData != null)
        {
            _score.text = playerData.Score.ToString();
        }
    }
}
