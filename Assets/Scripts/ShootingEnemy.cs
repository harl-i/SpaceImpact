using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class ShootingEnemy : SpaceFlyingObject, IObjectFromPool
{
    [SerializeField] private float _firstShootDelay;
    [SerializeField] protected ObjectPool _bulletsPool;
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected float _shootDelay;

    public static event UnityAction<int> RewardAccrual;

    public override void Die()
    {
        base.Die();
        RewardAccrual?.Invoke(_reward);
    }

    protected void Shoot()
    {
        GameObject bullet;
        _bulletsPool.TryGetObject(out bullet);

        if (bullet != null)
        {
            bullet.transform.position = _shootPoint.transform.position;
            bullet.SetActive(true);
        }
        else
        {
            Debug.Log("bullets pool is empty");
        }
    }

    private void Awake()
    {
        _bulletsPool = FindObjectOfType<EnemyBulletsPool>();
    }

    private void OnEnable()
    {
        StartCoroutine(StartShoot(_firstShootDelay));
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
