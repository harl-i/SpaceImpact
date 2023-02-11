using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private float _bulletSpeed;

    public event UnityAction EnemyDying;

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
