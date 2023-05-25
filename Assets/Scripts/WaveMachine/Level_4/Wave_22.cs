using System.Collections;
using UnityEngine;

public class Wave_22 : Wave
{
    private int _enemiesCount = 8;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _enemiesCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[2], _moveVariant);
            yield return delay;
        }
    }
}
