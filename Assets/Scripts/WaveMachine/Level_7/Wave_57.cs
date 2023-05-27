using System.Collections;
using UnityEngine;

public class Wave_57 : Wave
{
    private int _iterations = 2;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayBetweenIterations = new WaitForSeconds(4f);

        for (int i = 0; i < _iterations; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[2], _moveVariant);
            yield return delay;

            SpawnEnemy(_enemiesPool, _spawnPoints[1], _moveVariant);
            SpawnEnemy(_enemiesPool, _spawnPoints[3], _moveVariant);
            yield return delay;

            SpawnEnemy(_enemiesPool, _spawnPoints[0], _moveVariant);
            SpawnEnemy(_enemiesPool, _spawnPoints[4], _moveVariant);

            yield return delayBetweenIterations;
        }
    }
}
