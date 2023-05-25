using System.Collections;
using UnityEngine;

public class Wave_36 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds delayBeforeBonus = new WaitForSeconds(_spawnDelay * 2f);

        for (int i = _spawnPoints.Count - 1; i >= 0; i--)
        {
            if (i != 0)
            {
                SpawnEnemy(_enemiesPool, _spawnPoints[i], _moveVariant);
                yield return delay;
            }
            else
            {
                yield return delayBeforeBonus;
                SpawnBonus(_bonus, _spawnPoints[i], _bonusSpeed, _canVerticalMoveBonus);
            }
        }
    }
}
