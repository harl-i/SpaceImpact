using UnityEngine;
using UnityEngine.Events;

public class Enemy : SpaceFlyingObject, IObjectFromPool, IEnemyDying
{
    [SerializeField] private float _speed;

    public static event UnityAction EnemyDying;

    public void Disable()
    {
        EnemyDying?.Invoke();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
