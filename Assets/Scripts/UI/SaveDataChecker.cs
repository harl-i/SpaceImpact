using UnityEngine;

public class SaveDataChecker : MonoBehaviour
{
    [SerializeField] private GameObject _continueButton;

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
            _continueButton.SetActive(true);
        }
    }
}
