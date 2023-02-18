using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_1 : Wave
{
    [SerializeField] protected EnemyPool _enemysPool;

    private float _spawnDelay = 3;

    private Dictionary<int, int> _enemyCountOnIteration = new Dictionary<int, int>()
    {
        {0, 3},
        {1, 2},
        {2, 3}
    };

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        for (int i = 0; i < _enemyCountOnIteration.Count; i++)
        {
            yield return StartCoroutine(Spawn(_enemysPool, _spawnDelay, _enemyCountOnIteration[i], _spawnPoints[i]));

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
