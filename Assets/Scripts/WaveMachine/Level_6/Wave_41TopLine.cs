using System.Collections;
using UnityEngine;

public class Wave_41TopLine : Wave
{
    private int _enemiesCount = 3;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayBeforeBonus = new WaitForSeconds(_spawnDelay * 3);

        for (int i = 0; i < _enemiesCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[0], _moveVariant);
            yield return delay;
        }
        yield return delayBeforeBonus;

        SpawnBonus(_bonus, _spawnPoints[1], _bonusSpeed, _canVerticalMoveBonus);
    }
}
