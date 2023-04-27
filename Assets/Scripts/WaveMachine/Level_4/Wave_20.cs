using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_20 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[1].transform.position, SwitchMoveTo));

        yield return new WaitForSeconds(5);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 2, _spawnPoints[0].transform.position, SwitchMoveTo));
        
        yield return new WaitForSeconds(5);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 2, _spawnPoints[2].transform.position, SwitchMoveTo));

        yield return new WaitForSeconds(5);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 3, _spawnPoints[1].transform.position, SwitchMoveTo));
    }
}
