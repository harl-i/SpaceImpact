using System.Collections;
using UnityEngine;

public class Wave_45 : Wave
{
    private int _enemiesCount = 7;
    private int _iterations = 2;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayBetweenIterations = new WaitForSeconds(_spawnDelay * 20);

        for (int j = 0; j < _iterations; j++)
        {
            for (int i = 0; i < _enemiesCount; i++)
            {
                SpawnEnemy(_enemiesPool, _spawnPoints[4], _moveVariant);
                yield return delay;
            }
            yield return delayBetweenIterations;
        }
    }
}
