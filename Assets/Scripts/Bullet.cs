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
        transform.Translate(new Vector2(0, -1) * _bulletSpeed * Time.deltaTime);
    }
}
