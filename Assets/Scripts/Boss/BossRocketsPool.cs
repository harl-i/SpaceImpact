using UnityEngine;

public class BossRocketsPool : ObjectPool
{
    [SerializeField] private Rocket _rocketPrefab;

    private void Awake()
    {
        Initialize(_rocketPrefab);
    }
}