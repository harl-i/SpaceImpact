using System.Collections;
using UnityEngine;

public class Wave_34 : Wave
{
    private int _enemiesCount = 4;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        for (int i = _enemiesCount; i > 0; i--)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[i - 1], _moveVariant);
            yield return delay;
        }
    }
}
