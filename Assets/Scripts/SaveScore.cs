using System.Runtime.InteropServices;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    private SaveLoadSystem _saveLoadSystem;

    [DllImport("__Internal")]
    private static extern void SetLeaderboardScore(int score);

    private void Awake()
    {
        _saveLoadSystem = new SaveLoadSystem(Application.persistentDataPath + "/save.json");
    }

    public void SavePlayerScoreToLeaderboard()
    {
        PlayerData playerData = _saveLoadSystem.Load();

        SetLeaderboardScore(playerData.Score);
    }
}
