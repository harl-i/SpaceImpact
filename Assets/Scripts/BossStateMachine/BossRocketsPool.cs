using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRocketsPool : ObjectPool
{
    [SerializeField] private Rocket _bulletPrefab;

    private void Awake()
    {
        Initialize(_bulletPrefab);
    }
}
