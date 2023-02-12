using UnityEngine;

public class EnemyBulletsPool : ObjectPool
{
    [SerializeField] private EnemyBullet _bulletPrefab;

    private void Awake()
    {
        Initialize(_bulletPrefab.gameObject);
    }
}
