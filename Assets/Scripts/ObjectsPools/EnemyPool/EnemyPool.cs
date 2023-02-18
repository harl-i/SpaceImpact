using UnityEngine;

public class EnemyPool : ObjectPool
{
    [SerializeField] private SpaceFlyingObject _enemy;

    private void Awake()
    {
        Initialize(_enemy);
    }
}
