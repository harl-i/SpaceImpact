using UnityEngine;

public class Laser : MonoBehaviour, IObjectFromPool
{
    private ObjectPool _pool;

    private int _damage = 5;
    private float _lifeTime = 1.5f;
    private float _elapsedTime;

    private void Awake()
    {
        _pool = FindObjectOfType<LasersPool>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ShootingEnemy shootingEnemy))
        {
            shootingEnemy.ApplyDamage(_damage);
        }

        if (collision.TryGetComponent(out NonShootingEnemy nonShootingEnemy))
        {
            nonShootingEnemy.ApplyDamage(_damage);
        }
    }

    private void OnEnable()
    {
        _elapsedTime = 0;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;


        if (_elapsedTime > _lifeTime)
        {
            ReturnToPool();
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ReturnToPool()
    {
        transform.SetParent(_pool.transform);
        gameObject.SetActive(false);
    }
}
