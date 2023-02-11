using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private Wave _targetWave;
    protected Enemy _enemy;

    public Wave TargetWave => _targetWave;

    public bool NeedTransit { get; protected set; }

    protected int _currentWaveEnemyCount;

    private void OnEnable()
    {
        NeedTransit = false;
        Enemy.EnemyDying += OnEnemyDying;
    }

    private void OnDisable()
    {
        Enemy.EnemyDying -= OnEnemyDying;
    }

    public void Init(Wave wave)
    {
        _currentWaveEnemyCount = wave.EnemyCount;
    }

    protected abstract void OnEnemyDying();
}
