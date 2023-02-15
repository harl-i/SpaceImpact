using UnityEngine;
using UnityEngine.Events;

public abstract class SpaceFlyingObject : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] protected ObjectPool _bulletsPool;
    [SerializeField] protected float _shootDelay;

    protected float _elapsedTime;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage()
    {
        _health--;
        HealthChanged?.Invoke(_health);
        Debug.Log(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public abstract void Die();

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
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
}
