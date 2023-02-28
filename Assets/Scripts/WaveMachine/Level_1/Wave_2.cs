using System.Collections;
using UnityEngine;

public class Wave_2 : Wave
{
    private int _enemysCount = 7;

    private void OnEnable()
    {
        StartCoroutine(ActivateSpawn());
    }

    private IEnumerator ActivateSpawn()
    {
        for (int i = 0; i < _enemysCount; i++)
        {
            int randomPoint = Random.Range(0, _spawnPoints.Count);
            yield return StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[randomPoint].transform.position, MoveVariant));
        }
    }
}
