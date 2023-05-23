using System.Collections;
using UnityEngine;

public class Wave_8 : Wave
{
    private int _enemiesCount = 4;
    private int _iterationForSpawnBonus = 1;

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

            if (i == _iterationForSpawnBonus && _bonus != null)
            {
                SpawnBonus(_bonus, _spawnPoints[1], _bonusSpeed);
            }

            yield return delay;
        }
    }
}
