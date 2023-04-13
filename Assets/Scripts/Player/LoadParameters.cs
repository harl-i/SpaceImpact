using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
public class LoadParameters : MonoBehaviour
{
    [SerializeField] private Score _score;
    private Player _player;

    private int _health;
    private int _rockets;
    private int _lasers;
    private int _lasersWalls;
    private int _scoreCount;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;

        if (sceneNumber != 0)
        {
            GetParameters();
            SetParameters();
        }
    }

    private void GetParameters()
    {
        _health = PlayerPrefs.GetInt(PlayerParameters.Health);
        _rockets = PlayerPrefs.GetInt(PlayerParameters.RocketsCount);
        _lasers = PlayerPrefs.GetInt(PlayerParameters.LasersCount);
        _lasersWalls = PlayerPrefs.GetInt(PlayerParameters.LaserWallsCount);
        _scoreCount = PlayerPrefs.GetInt(PlayerParameters.Score);
    }

    private void SetParameters()
    {
        _player.SetHelath(_health);
        _player.SetRockets(_rockets);
        _player.SetLasers(_lasers);
        _player.SetLasersWalls(_lasersWalls);
        _score.SetScore(_scoreCount);
    }
}
