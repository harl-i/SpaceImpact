using UnityEngine;

public class LaserWall : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage = 40;

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

        if (collision.TryGetComponent(out EnemyBullet enemyBullet))
        {
            enemyBullet.ReturnToPool();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
