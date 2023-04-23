using System.Collections.Generic;
using System.Data;
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

    public void Save()
    {
        PlayerPrefs.SetInt(PlayerParameters.Health, _player.Health);
        PlayerPrefs.SetInt(PlayerParameters.RocketsCount, _player.RocketsCount);
        PlayerPrefs.SetInt(PlayerParameters.LasersCount, _player.LasersCount);
        PlayerPrefs.SetInt(PlayerParameters.LaserWallsCount, _player.LaserWallsCount);
        PlayerPrefs.SetInt(PlayerParameters.Score, _score.ScoreCount);
        PlayerPrefs.SetString(PlayerParameters.ActiveSuperWeapon, GetSuperWeaponName());
    }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _rocketGun = GetComponent<RocketGun>();
        _laserGun = GetComponent<LaserGun>();
        _laserWallGun = GetComponent<LaserWallGun>();

        FillSuperWeaponList();
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
