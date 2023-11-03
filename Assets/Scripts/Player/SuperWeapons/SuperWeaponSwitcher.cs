using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RocketGun))]
[RequireComponent(typeof(LaserGun))]
[RequireComponent(typeof(LaserWallGun))]
public class SuperWeaponSwitcher : MonoBehaviour
{
    [SerializeField] private SuperWeaponButton _superWeaponButton;

    private RocketGun _rocketGun;
    private LaserGun _laserGun;
    private LaserWallGun _laserWallGun;

    public event UnityAction<SuperWeaponVariant> SwitchSuperWeapon;

    private void Awake()
    {
        _rocketGun = GetComponent<RocketGun>();
        _laserGun = GetComponent<LaserGun>();
        _laserWallGun = GetComponent<LaserWallGun>();
    }

    public void ActivateRocketGun()
    {
        DisableAll();
        _rocketGun.enabled = true;
        SwitchSuperWeapon?.Invoke(SuperWeaponVariant.Rocket);
        _superWeaponButton.SetSuperWeapon(SuperWeaponVariant.Rocket);
    }

    public void ActivateLaserGun()
    {
        DisableAll();
        _laserGun.enabled = true;
        SwitchSuperWeapon?.Invoke(SuperWeaponVariant.Laser);
        _superWeaponButton.SetSuperWeapon(SuperWeaponVariant.Laser);
    }

    public void ActivateLaserWallGun()
    {
        DisableAll();
        _laserWallGun.enabled = true;
        SwitchSuperWeapon?.Invoke(SuperWeaponVariant.LaserWall);
        _superWeaponButton.SetSuperWeapon(SuperWeaponVariant.LaserWall);
    }

    private void DisableAll()
    {
        _rocketGun.enabled = false;
        _laserGun.enabled = false;
        _laserWallGun.enabled = false;
    }
}
