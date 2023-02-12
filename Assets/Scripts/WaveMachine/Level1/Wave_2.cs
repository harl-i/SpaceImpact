using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_2 : Wave
{
    [SerializeField] private Enemy _enemyPrefab;

    private int _enabledEnemy = 0;
    private float _spawnDelay = 3;
    private float _elapsedTime;

    private void Update()
    {
        if (_enabledEnemy >= _enemyCount)
        {
            return;
        }

        EnableEnemy();

        _elapsedTime += Time.deltaTime;
    }

    private void EnableEnemy()
    {
        if (_elapsedTime > _spawnDelay)
        {
            Instantiate(_enemyPrefab, _spawnPoints[1].transform);
            _enabledEnemy++;
            _elapsedTime = 0;
        }
    }
}
