using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsPool : ObjectPool
{
    [SerializeField] private Bullet _bulletPrefab;

    private void Awake()
    {
        Initialize(_bulletPrefab.gameObject);
    }
}
