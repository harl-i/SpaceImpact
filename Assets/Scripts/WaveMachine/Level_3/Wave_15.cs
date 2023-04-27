using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_15 : Wave
{
    private int _enemiesCountOnWave = 2;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        for (int i = 0; i < _enemiesCountOnWave; i++)
        {
            StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[i].transform.position, SwitchMoveTo));
        }
        yield return null;
    }
}
