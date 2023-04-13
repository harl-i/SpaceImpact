using UnityEngine;

[RequireComponent(typeof(Player))]
public class SaveParameters : MonoBehaviour
{
    [SerializeField] private Score _score;
    private Player _player;

    public void Save()
    {
        PlayerPrefs.SetInt(PlayerParameters.Health, _player.Health);
        PlayerPrefs.SetInt(PlayerParameters.RocketsCount, _player.RocketsCount);
        PlayerPrefs.SetInt(PlayerParameters.LasersCount, _player.LasersCount);
        PlayerPrefs.SetInt(PlayerParameters.LaserWallsCount, _player.LaserWallsCount);
        PlayerPrefs.SetInt(PlayerParameters.Score, _score.ScoreCount);
    }

    private void Start()
    {
        _player = GetComponent<Player>();
    }
}
