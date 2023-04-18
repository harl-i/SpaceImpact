using UnityEngine;

public class LaserGun : SuperWeapon
{
    [SerializeField] private LasersPool _pool;

    public override SuperWeaponVariant GetSuperWeaponType()
    {
        return SuperWeaponVariant.Laser;
    }

    protected override void OnSuperShoot()
    {
        if (_elapsedTime > _shootDelay && _player.LasersCount > 0)
        {
            Shoot();
            _player.ReduceLaser();
            _elapsedTime = 0;
        }
    }

    protected override void Shoot()
    {
        GameObject laser;
        _pool.TryGetObject(out laser);

        if (laser != null)
        {
            laser.transform.SetParent(_player.ShootPoint);
            laser.transform.position = _player.ShootPoint.position;
            laser.SetActive(true);
        }
    }
}
