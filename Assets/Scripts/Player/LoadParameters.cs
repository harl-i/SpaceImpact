using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(RocketGun))]
[RequireComponent(typeof(LaserGun))]
[RequireComponent(typeof(LaserWallGun))]
[RequireComponent(typeof(SuperWeaponSwitcher))]
public class LoadParameters : MonoBehaviour
{
    [SerializeField] private Score _score;

    private Player _player;
    private SuperWeaponSwitcher _superWeaponSwitcher;
    private int _health;
    private int _rockets;
    private int _lasers;
    private int _lasersWalls;
    private int _scoreCount;
    private string _activeSuperWeapon;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _superWeaponSwitcher = GetComponent<SuperWeaponSwitcher>();
    }

    private void Start()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;

        if (sceneNumber != 0)
        {
            GetParameters();
            SetParameters();
            ActivateSuperWeapon();
        }
    }

    private void GetParameters()
    {
        _health = PlayerPrefs.GetInt(PlayerParameters.Health);
        _rockets = PlayerPrefs.GetInt(PlayerParameters.RocketsCount);
        _lasers = PlayerPrefs.GetInt(PlayerParameters.LasersCount);
        _lasersWalls = PlayerPrefs.GetInt(PlayerParameters.LaserWallsCount);
        _scoreCount = PlayerPrefs.GetInt(PlayerParameters.Score);
        _activeSuperWeapon = PlayerPrefs.GetString(PlayerParameters.ActiveSuperWeapon);
    }

    private void SetParameters()
    {
        _player.SetHelath(_health);
        _player.SetRockets(_rockets);
        _player.SetLasers(_lasers);
        _player.SetLasersWalls(_lasersWalls);
        _score.SetScore(_scoreCount);
    }

    private void ActivateSuperWeapon()
    {
        if (_activeSuperWeapon == SuperWeaponVariant.Rocket.ToString())
        {
            _superWeaponSwitcher.ActivateRocketGun();
        }
        else if (_activeSuperWeapon == SuperWeaponVariant.Laser.ToString())
        {
            _superWeaponSwitcher.ActivateLaserGun();
        }
        else if (_activeSuperWeapon == SuperWeaponVariant.LaserWall.ToString())
        {
            _superWeaponSwitcher.ActivateLaserWallGun();
        }
    }
}
