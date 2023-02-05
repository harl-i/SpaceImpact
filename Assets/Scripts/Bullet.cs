using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IObjectFromPool
{
    [SerializeField] private float _bulletSpeed;

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);
    }
}
