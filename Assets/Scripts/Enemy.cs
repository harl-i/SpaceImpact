using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : SpaceFlyingObject, IObjectFromPool
{
    [SerializeField] private float _speed;
    [SerializeField] private int _reward;
    [SerializeField] private float _firstShootDelay;

    public static event UnityAction<int> RewardAccrual;

    public void ReturnToPool()
    {
        Debug.Log("Enemy Die");
        gameObject.SetActive(false);
    }

    public override void Die()
    {
        RewardAccrual?.Invoke(_reward);
        ReturnToPool();
    }

    private void Awake()
    {
        _bulletsPool = FindObjectOfType<EnemyBulletsPool>();
    }

    private void OnEnable()
    {
        StartCoroutine(StartShoot(_firstShootDelay));
    }


    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
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
