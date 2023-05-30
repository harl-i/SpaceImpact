using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShootingEnemy : SpaceFlyingObject, IObjectFromPool
{
    [SerializeField] private float _firstShootDelay;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private BossPuff _bossPuff;
    [SerializeField] private EnemyBulletsPool _bulletsPool;

    private int _collisionDamage = 1;

    public static event UnityAction<int> RewardAccrual;

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(StartShoot(_firstShootDelay));
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_collisionDamage);
            Die();
        }
    }

    protected override void Die()
    {
        RewardAccrual?.Invoke(_reward);

        if (_isBoss)
        {
            BossDie();
        }

        base.Die();
    }

    private void BossDie()
    {
        _bossDeathNotifier.enabled = true;
        Instantiate(_bossPuff, gameObject.transform.position, Quaternion.identity);
    }

    private void Shoot()
    {
        if (_bulletsPool != null)
        {

            _bulletsPool.TryGetObject(out GameObject bullet);

            if (bullet != null)
            {
                bullet.transform.position = _shootPoint.transform.position;
                if (bullet.transform.parent != null)
                {
                    bullet.transform.SetParent(null);

                }
                bullet.SetActive(true);
            }
            else
            {
                Debug.Log("bullets pool is empty");
            }
        }
    }

    private IEnumerator StartShoot(float firstShootDelay)
    {
        yield return new WaitForSeconds(firstShootDelay);

        Shoot();

        yield return new WaitForSeconds(_shootDelay);

        StartCoroutine(Shooting(_shootDelay));
    }

    private IEnumerator Shooting(float delay)
    {
        while (true)
        {
            Shoot();

            yield return new WaitForSeconds(delay);
        }
    }
}
