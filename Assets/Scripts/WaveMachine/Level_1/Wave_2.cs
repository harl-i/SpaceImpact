using System.Collections;
using UnityEngine;

public class Wave_2 : Wave
{
    private float _spawnDelay = 2.5f;
    private int _enemysCount = 7;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        for (int i = 0; i < _enemysCount; i++)
        {
            int randomPoint = Random.Range(0, _spawnPoints.Count);
            yield return StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[randomPoint]));
        }
    }
}
