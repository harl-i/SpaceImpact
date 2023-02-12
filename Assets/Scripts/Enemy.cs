using UnityEngine;
using UnityEngine.Events;

public class Enemy : SpaceFlyingObject, IObjectFromPool, IEnemyDying
{
    [SerializeField] private float _speed;
    [SerializeField] private int _reward;

    public static event UnityAction<int> EnemyDying;

    public void Disable()
    {
        EnemyDying?.Invoke(_reward);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
