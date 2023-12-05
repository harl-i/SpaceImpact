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

    private SaveLoadSystem _saveLoadSystem;
    private Player _player;
    private SuperWeaponSwitcher _superWeaponSwitcher;
    private string _activeSuperWeapon;

    private void Awake()
    {
        _saveLoadSystem = new SaveLoadSystem(Application.persistentDataPath + "/save.json");
        _player = GetComponent<Player>();
        _superWeaponSwitcher = GetComponent<SuperWeaponSwitcher>();
    }

    private void Start()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;

        Load();

        if (sceneNumber != 1)
        {
            ActivateSuperWeapon();
        }
    }

    public void Load()
    {
        PlayerData playerData = _saveLoadSystem.Load();

        if (playerData != null)
        {
            _player.SetHelath(playerData.Health);
            _player.SetRockets(playerData.RocketsCount);
            _player.SetLasers(playerData.LasersCount);
            _player.SetLasersWalls(playerData.LaserWallsCount);
            _player.SetContinuums(playerData.ContinuumsCount);
            _score.SetScore(playerData.Score);
            _activeSuperWeapon = playerData.ActiveSuperWeapon;
            _player.SetCurrentLevel(playerData.CurrentLevel);
        }
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
