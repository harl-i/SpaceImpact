using System.Collections;
using UnityEngine;

public class Wave_20 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds longDelay = new WaitForSeconds(_spawnDelay * 3);

        int[] spawnPointOrder = { 2, 0, 0, 0, 3, 1, 1, 1 };
        int spawnOrderIndex = 0;

        for (int i = 0; i < spawnPointOrder.Length; i++)
        {
            int pointIndex = spawnPointOrder[spawnOrderIndex];
            spawnOrderIndex++;

            if (spawnOrderIndex >= spawnPointOrder.Length)
            {
                spawnOrderIndex = 0;
            }

            SpawnEnemy(_enemiesPool, _spawnPoints[pointIndex], _moveVariant);

            if (spawnOrderIndex == 1 || spawnOrderIndex == 4 || spawnOrderIndex == 5)
            {
                yield return longDelay;
            }
            else
            {
                yield return delay;
            }
        }

        yield return longDelay;
        SpawnBonus(_bonus, _spawnPoints[2], _bonusSpeed, _canVerticalMoveBonus);
    }
}
