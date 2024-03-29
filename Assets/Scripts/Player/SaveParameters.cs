using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(RocketGun))]
[RequireComponent(typeof(LaserGun))]
[RequireComponent(typeof(LaserWallGun))]
public class SaveParameters : MonoBehaviour
{
    [SerializeField] private Score _score;

    private List<SuperWeapon> _superWeaponsList = new List<SuperWeapon>();
    private RocketGun _rocketGun;
    private LaserGun _laserGun;
    private LaserWallGun _laserWallGun;
    private Player _player;

    private SaveLoadSystem _saveLoadSystem;

    private void Awake()
    {
        _saveLoadSystem = new SaveLoadSystem(Application.persistentDataPath + "/save.json");

        _player = GetComponent<Player>();
        _rocketGun = GetComponent<RocketGun>();
        _laserGun = GetComponent<LaserGun>();
        _laserWallGun = GetComponent<LaserWallGun>();

        FillSuperWeaponList();
    }

    public void Save()
    {
        PlayerData playerData = new PlayerData
        {
            Health = _player.Health,
            RocketsCount = _player.RocketsCount,
            LasersCount = _player.LasersCount,
            LaserWallsCount = _player.LaserWallsCount,
            Score = _score.ScoreCount,
            ActiveSuperWeapon = GetSuperWeaponName(),
            ContinuumsCount = _player.Continuum,
            CurrentLevel = _player.CurrentLevel + 1
        };

        _saveLoadSystem.Save(playerData);
    }

    private void FillSuperWeaponList()
    {
        _superWeaponsList.Add(_rocketGun);
        _superWeaponsList.Add(_laserGun);
        _superWeaponsList.Add(_laserWallGun);
    }

    private SuperWeaponVariant GetActiveSuperWeapon()
    {
        foreach (var weapon in _superWeaponsList)
        {
            if (weapon.enabled == true)
            {
                return weapon.GetSuperWeaponType();
            }
        }

        return SuperWeaponVariant.Rocket;
    }

    private string GetSuperWeaponName()
    {
        switch (GetActiveSuperWeapon())
        {
            case SuperWeaponVariant.Rocket:
                return PlayerParameters.RocketGun;
            case SuperWeaponVariant.Laser:
                return PlayerParameters.LaserGun;
            case SuperWeaponVariant.LaserWall:
                return PlayerParameters.LaserWallGun;
            default:
                return null;
        }
    }
}
