using UnityEngine;

public class RocketGun : SuperWeapon
{
    [SerializeField] private RocketsPool _pool;

    protected override void OnSuperShoot()
    {
        if (_elapsedTime > _shootDelay && _player.RocketsCount > 0)
        {
            Shoot();
            _player.ReduceRocket();
            _elapsedTime = 0;
        }
    }

    protected override void Shoot()
    {
        GameObject rocket;
        _pool.TryGetObject(out rocket);

        if (rocket != null)
        {
            rocket.transform.position = _player.ShootPoint.position;
            rocket.SetActive(true);
        }
    }
}
