using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private SaveLoadSystem _saveLoadSystem;
    private int _score;

    public int ScoreCount => _score;

    [DllImport("__Internal")]
    private static extern void SetLeaderboardScore(int score);

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _saveLoadSystem = new SaveLoadSystem(Application.persistentDataPath + "/save.json");
    }

    private void OnEnable()
    {
        Player.PlayerDied += OnPlayerDied;
        ShootingEnemy.RewardAccrual += OnAccrual;
        NonShootingEnemy.RewardAccrual += OnAccrual;
    }

    private void OnDisable()
    {
        Player.PlayerDied -= OnPlayerDied;
        ShootingEnemy.RewardAccrual -= OnAccrual;
        NonShootingEnemy.RewardAccrual -= OnAccrual;
    }

    public void SetScore(int count)
    {
        _score = count;
        _textMeshPro.text = _score.ToString();

        //SetLeaderboardScore(_score);
    }

    private void OnPlayerDied()
    {
        SaveScoreToPlayerData();
    }

    private void SaveScoreToPlayerData()
    {
        PlayerData playerData = _saveLoadSystem.Load();

        if (playerData != null)
        {
            playerData.Score = _score;
            _saveLoadSystem.Save(playerData);
        }
    }

    private void OnAccrual(int reward)
    {
        _score += reward;

        _textMeshPro.text = _score.ToString();
    }
}
