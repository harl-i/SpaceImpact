using System.Collections.Generic;
using UnityEngine;

public class Wave_31 : Wave
{
    private int _enemiesCountOnWave = 2;

    private void OnEnable()
    {
        //StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _moveVariant));
    }
}
