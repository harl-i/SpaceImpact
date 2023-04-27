using System.Collections;
using UnityEngine;

public class Wave_11 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 5, _spawnPoints[2].transform.position, SwitchMoveTo));

        yield return new WaitForSeconds(12f);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[0].transform.position, SwitchMoveTo));

        yield return new WaitForSeconds(3f);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[2].transform.position, SwitchMoveTo));

        yield return new WaitForSeconds(3f);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 2, _spawnPoints[1].transform.position, SwitchMoveTo));

        yield return new WaitForSeconds(6f);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[2].transform.position, SwitchMoveTo));

        yield return new WaitForSeconds(3);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[0].transform.position, SwitchMoveTo));
    }
}
