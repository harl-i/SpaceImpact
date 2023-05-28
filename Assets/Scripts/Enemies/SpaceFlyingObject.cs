using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MoveSwitcher))]
public abstract class SpaceFlyingObject : MonoBehaviour, IObjectFromPool, IDamageable
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _reward;
    [SerializeField] private EnemyDeathNotifier _enemyDeathNotifier;
    [SerializeField] protected bool _isBoss;
    [SerializeField] private Blink _blink;

    private bool _isCoroutineRunning = false;
    protected float _elapsedTime;
    private int _currentHealth;

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

    protected virtual void OnEnable()
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
    }

    private IEnumerator BlinkActivate()
    {
        _blink.enabled = true;
        yield return new WaitForSeconds(_blink.BlinkingTime);
        _blink.enabled = false;
        _isCoroutineRunning = false;
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}