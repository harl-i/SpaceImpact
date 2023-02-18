using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class SpaceFlyingObject : MonoBehaviour, IObjectFromPool
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _health;
    [SerializeField] protected int _reward;

    protected float _elapsedTime;
    private int _currentHealth;

    public void ApplyDamage()
    {
        _currentHealth--;
        Debug.Log(_health);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    protected virtual void Die()
    {
        ReturnToPool();
    }

    private void OnEnable()
    {
        RestoreHealth();
    }

    private void RestoreHealth()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}