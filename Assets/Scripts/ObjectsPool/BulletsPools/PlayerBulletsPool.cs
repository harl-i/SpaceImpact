using UnityEngine;

public class PlayerBulletsPool : ObjectPool
{
    [SerializeField] private PlayerBullet _bulletPrefab;

    private void Awake()
    {
        Initialize(_bulletPrefab);
    }
}
