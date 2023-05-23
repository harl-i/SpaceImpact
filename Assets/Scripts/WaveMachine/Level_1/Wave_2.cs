using System.Collections;
using UnityEngine;

public class Wave_2 : Wave
{
    private int _enemysCount = 10;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _enemysCount; i++)
        {
            int randomPoint = Random.Range(0, _spawnPoints.Count);
            SpawnEnemy(_enemiesPool, _spawnPoints[randomPoint], _moveVariant);

            yield return spawnDelay;
        }
    }
}
