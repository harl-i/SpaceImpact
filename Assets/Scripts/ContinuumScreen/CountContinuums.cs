using TMPro;
using UnityEngine;

public class CountContinuums : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _continuumsCount;
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
            _continuumsCount.text = playerData.ContinuumsCount.ToString();
        }
    }
}
