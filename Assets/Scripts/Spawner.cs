using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;

    private void Start()
    {
        Initialize(_bulletPrefab);
    }

    //public bool TryGetBullet()
    //{
    //    TryGetObject()
    //}
}
