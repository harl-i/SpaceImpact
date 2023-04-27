using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_9 : Wave
{
    private int _enemiesCountOnWave = 5;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, SwitchMoveTo));
    }
}
