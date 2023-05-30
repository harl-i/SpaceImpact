using System.Collections;
using UnityEngine;

public class Wave_3 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(ActivateSpawn());
    }

    private IEnumerator ActivateSpawn()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        int[] spawnPointOrder = { 2, 1, 1 };
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