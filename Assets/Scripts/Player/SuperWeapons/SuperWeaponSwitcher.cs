using UnityEngine;

[RequireComponent(typeof(RocketGun))]
[RequireComponent(typeof(LaserGun))]
[RequireComponent(typeof(LaserWallGun))]
public class SuperWeaponSwitcher : MonoBehaviour
{
    private RocketGun _rocketGun;
    private LaserGun _laserGun;
    private LaserWallGun _laserWallGun;

    public void ActivateRocketGun()
    {
        DisableAll();
        _rocketGun.enabled = true;
    }

    public void ActivateLaserGun()
    {
        DisableAll();
        _laserGun.enabled = true;
    }

    public void ActivateLaserWallGun()
    {
        DisableAll();
        _laserWallGun.enabled = true;
    }

    private void Awake()
    {
        _rocketGun = GetComponent<RocketGun>();
        _laserGun = GetComponent<LaserGun>();
        _laserWallGun = GetComponent<LaserWallGun>();
    }

    private void DisableAll()
    {
        _rocketGun.enabled = false;
        _laserGun.enabled = false;
        _laserWallGun.enabled = false;
    }
}
