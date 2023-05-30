using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private int _score;

    public int ScoreCount => _score;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ShootingEnemy.RewardAccrual += OnAccrual;
        NonShootingEnemy.RewardAccrual += OnAccrual;
    }

    private void OnDisable()
    {
        ShootingEnemy.RewardAccrual -= OnAccrual;
        NonShootingEnemy.RewardAccrual -= OnAccrual;
    }

    public void SetScore(int count)
    {
        _score = count;
        _textMeshPro.text = _score.ToString();
    }

    private void OnAccrual(int reward)
    {
        _score += reward;

        _textMeshPro.text = _score.ToString();
    }
}
