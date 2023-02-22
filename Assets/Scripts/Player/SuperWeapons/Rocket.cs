using UnityEngine;

public class Rocket : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
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

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
