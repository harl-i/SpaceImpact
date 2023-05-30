using System.Collections;
using UnityEngine;

public class Wave_51 : Wave
{
    private int _enemiesCount = 2;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _enemiesCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[0], _moveVariant);
            yield return delay;
        }
    }
}
