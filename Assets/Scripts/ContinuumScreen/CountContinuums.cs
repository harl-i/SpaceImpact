using System.IO;
using TMPro;
using UnityEngine;

public class CountContinuums : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _continuumsCount;

    private void Start()
    {
        _continuumsCount.text = PlayerPrefs.GetInt(PlayerParameters.Continuum).ToString();

        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/save.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            _continuumsCount.text = playerData.ContinuumsCount.ToString();
        }
    }
}
