using System.Collections;
using UnityEngine;

public class Wave_1 : Wave
{
    private int _sixthIteration = 6;
    private int _eleventhIteration = 11;
    private int _twelfthIteration = 12;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);
        WaitForSeconds doubleDelay = new WaitForSeconds(_spawnDelay * 2);
        WaitForSeconds shortDelay = new WaitForSeconds(0.5f);

        int[] spawnPointOrder = { 0, 0, 0, 1, 1, 1, 1, 3, 3, 3, 1, 1, 1 };
        int spawnOrderIndex = 0;

        for (int i = 0; i < spawnPointOrder.Length; i++)
        {
            int pointIndex = spawnPointOrder[spawnOrderIndex];
            spawnOrderIndex++;

            if (spawnOrderIndex >= spawnPointOrder.Length)
            {
                spawnOrderIndex = 0;
            }

            if (spawnOrderIndex == _sixthIteration)
            {
                yield return doubleDelay;
                SpawnEnemy(_enemiesPool, _spawnPoints[pointIndex], _moveVariant);
                yield return delay;
            }
            else if (spawnOrderIndex == _eleventhIteration)
            {
                SpawnEnemy(_enemiesPool, _spawnPoints[pointIndex], _moveVariant);
                yield return shortDelay;
            }
            else if (spawnOrderIndex == _twelfthIteration)
            {
                SpawnBonus(_bonus, _spawnPoints[pointIndex], _bonusSpeed, _canVerticalMoveBonus);
                yield return delay;
            }
            else
            {
                SpawnEnemy(_enemiesPool, _spawnPoints[pointIndex], _moveVariant);
                yield return delay;
            }
        }
    }
}
