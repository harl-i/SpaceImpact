using System.Collections;
using UnityEngine;

public class Wave_38TopLine : Wave
{
    private int _enemiesCount = 3;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _enemiesCount; i++)
        {
            if (i == 0)
            {
                SpawnBonus(_bonus, _spawnPoints[2], _bonusSpeed, _canVerticalMoveBonus);
            }

            SpawnEnemy(_enemiesPool, _spawnPoints[1], _moveVariant);
            yield return delay;
        }
    }
}
