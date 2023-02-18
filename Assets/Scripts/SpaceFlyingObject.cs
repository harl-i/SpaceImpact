using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class SpaceFlyingObject : MonoBehaviour, IObjectFromPool
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _health;
    [SerializeField] protected int _reward;

    protected float _elapsedTime;

    public void ApplyDamage()
    {
        _health--;
        Debug.Log(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
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