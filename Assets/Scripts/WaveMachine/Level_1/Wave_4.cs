using System.Collections;
using UnityEngine;

public class Wave_4 : Wave
{
    private int _enemysCount = 4;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _enemysCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[2], _moveVariant);
            yield return delay;
        }
    }
}
