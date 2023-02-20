using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class SpaceFlyingObject : MonoBehaviour, IObjectFromPool
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _reward;
    //[SerializeField] protected Move _linearMove;
    //[SerializeField] protected Move _chaoticMove;


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

    //public void SetMoveVariant(MoveVariants move)
    //{
    //    switch (move)
    //    {
    //        case MoveVariants.Linear:
    //            _linearMove.enabled = true;
    //            break;
    //        case MoveVariants.Chaotic:
    //            _chaoticMove.enabled = true;
    //            break;
    //        default:
    //            break;
    //    }
    //}

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
    }
}