using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_17 : Wave
{
    private int _enemiesCountOnWave = 6;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, SwitchMoveTo));
    }
}
