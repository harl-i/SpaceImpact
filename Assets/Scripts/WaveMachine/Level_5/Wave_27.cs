using System.Collections;
using UnityEngine;

public class Wave_27 : Wave
{
    private int _enemiesCount = 9;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayAfterBonus = new WaitForSeconds(_spawnDelay * 3);

        SpawnBonus(_bonus, _spawnPoints[3], _bonusSpeed, _canVerticalMoveBonus);

        yield return delayAfterBonus;

        for (int i = 0; i < _enemiesCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[4], _moveVariant);
            yield return delay;
        }
    }
}
