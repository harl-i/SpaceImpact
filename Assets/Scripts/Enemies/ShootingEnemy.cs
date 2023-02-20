using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShootingEnemy : SpaceFlyingObject, IObjectFromPool
{
    [SerializeField] private float _firstShootDelay;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;

    private ObjectPool _bulletsPool;

    public static event UnityAction<int> RewardAccrual;

    protected override void Die()
    {
        base.Die();
        RewardAccrual?.Invoke(_reward);
    }

    private void Shoot()
    {
        _bulletsPool.TryGetObject(out GameObject bullet);

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

    private void Start()
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