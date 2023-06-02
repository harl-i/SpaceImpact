using System.Collections;
using UnityEngine;

public class Wave_60 : Wave
{
    private int _enemiesCount = 8;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _enemiesCount; i++)
        {
            int randomPoint = Random.Range(0, _spawnPoints.Count);
            SpawnEnemy(_enemiesPool, _spawnPoints[randomPoint], _moveVariant);

            yield return spawnDelay;
        }
    }
}
