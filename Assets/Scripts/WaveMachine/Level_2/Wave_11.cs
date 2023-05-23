using System.Collections;
using UnityEngine;

public class Wave_11 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        int[] spawnPointOrder = { 2, 2, 2, 2, 2, 0, 0, 3, 3, 1, 3 };
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
            yield return delay;
        }
    }
}
