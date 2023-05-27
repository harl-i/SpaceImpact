using System.Collections;
using UnityEngine;

public class Wave_58 : Wave
{
    private int[] _orderSpawnPoints = { 0, 2 };
    private int _enemiesCountOnIteration = 5;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayBetweenIterations = new WaitForSeconds(_spawnDelay * 3);

        for (int j = 0; j < _orderSpawnPoints.Length; j++)
        {
            for (int i = 0; i < _enemiesCountOnIteration; i++)
            {
                SpawnEnemy(_enemiesPool, _spawnPoints[j+1], _moveVariant);
                SpawnEnemy(_enemiesPool, _spawnPoints[j+2], _moveVariant);
                yield return delay;
            }
            yield return delayBetweenIterations;
        }
    }
}
