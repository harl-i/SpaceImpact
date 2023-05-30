using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MoveSwitcher))]
public abstract class SpaceFlyingObject : MonoBehaviour, IObjectFromPool, IDamageable
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _reward;
    [SerializeField] protected BossDeathNotifier _bossDeathNotifier;
    [SerializeField] protected bool _isBoss;
    [SerializeField] protected bool _canDeathNotfy;
    [SerializeField] protected bool _canShoot;
    [SerializeField] private EnemyDeathNotifier _enemyDeathNotifier;
    [SerializeField] private Blink _blink;

    protected float _elapsedTime;
    private int _currentHealth;
    private Transform _parent;
    private bool _isCoroutineRunning = false;

    private void Awake()
    {
        if (transform.parent != null)
        {
            _parent = transform.parent.transform;
        }
    }

    protected virtual void OnEnable()
    {
        RestoreHealth();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        if (_isBoss && _isCoroutineRunning == false)
        {
            _isCoroutineRunning = true;
            StartCoroutine(BlinkActivate());
        }

        if (_currentHealth <= 0)
        {
            if (_enemyDeathNotifier != null)
            {
                _enemyDeathNotifier.Notify();
            }

            Die();
        }
    }

    public void ReturnToPool()
    {
        if (transform.parent == null)
        {
            transform.SetParent(_parent);
        }
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

    private void RestoreHealth()
    {
        _currentHealth = _health;
    }

    private IEnumerator BlinkActivate()
    {
        _blink.enabled = true;
        yield return new WaitForSeconds(_blink.BlinkingTime);
        _blink.enabled = false;
        _isCoroutineRunning = false;
    }
}