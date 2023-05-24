using System.Collections;
using UnityEngine;

public class Wave_13 : Wave
{
    private int _enemiesCount = 3;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayBeforeBonus = new WaitForSeconds(0.35f);

        for (int i = 0; i < _enemiesCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[4], _moveVariant);

            if (i != _enemiesCount - 1)
            {
                yield return delay;
            }
            else
            {
                yield return delayBeforeBonus;
            }

        }
        SpawnBonus(_bonus, _spawnPoints[3], _bonusSpeed);
    }
}
