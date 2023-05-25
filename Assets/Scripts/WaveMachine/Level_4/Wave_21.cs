using System.Collections;
using UnityEngine;

public class Wave_21 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        int[] spawnPointOrder = { 0, 1, 2, 3, 4, 3, 2, 1, 0, 1};
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

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
