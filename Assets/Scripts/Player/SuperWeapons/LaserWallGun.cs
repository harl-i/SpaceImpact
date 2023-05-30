using UnityEngine;

public class LaserWallGun : SuperWeapon
{
    [SerializeField] private LaserWallPool _pool;

    public override SuperWeaponVariant GetSuperWeaponType()
    {
        return SuperWeaponVariant.LaserWall;
    }

    protected override void OnSuperShoot()
    {
        if (_elapsedTime > _shootDelay && _player.LaserWallsCount > 0)
        {
            Shoot();
            _player.ReduceLaserWall();
            _elapsedTime = 0;
        }
    }

    protected override void Shoot()
    {
        GameObject laserWall;
        _pool.TryGetObject(out laserWall);

        if (laserWall != null)
        {
            laserWall.transform.position = _player.ShootPoint.position;
            laserWall.transform.SetParent(null);
            laserWall.SetActive(true);
        }
    }
}
