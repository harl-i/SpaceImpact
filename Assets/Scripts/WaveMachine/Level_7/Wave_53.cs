using System.Collections;
using UnityEngine;

public class Wave_53 : Wave
{
    private int[] _spawnPointsOrder = { 1, 4, 1 };
    private int _enemiesCountOnIteration = 4;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayBetweenIterations = new WaitForSeconds(_spawnDelay * 3);

        for (int i = 0; i < _spawnPointsOrder.Length; i++)
        {
            for (int j = 0; j < _enemiesCountOnIteration; j++)
            {
                SpawnEnemy(_enemiesPool, _spawnPoints[_spawnPointsOrder[i]], _moveVariant);
                yield return delay;
            }
            yield return delayBetweenIterations;
        }
    }
}
