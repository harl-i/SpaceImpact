using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_1 : Wave
{
    [SerializeField] private Bonus bonus;

    private Dictionary<int, int> _enemyCountOnIteration = new Dictionary<int, int>()
    {
        {0, 3},
        {1, 2},
        {2, 3},
        {3, 1}
    };

    private void OnEnable()
    {
        StartCoroutine(ActivateSpawn());
    }

    private IEnumerator ActivateSpawn()
    {
        int j = 0;
        for (int i = 0; i < _enemyCountOnIteration.Count; i++)
        {
            if (j > _spawnPoints.Count - 1)
                j = 0;

            yield return StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemyCountOnIteration[i], _spawnPoints[j]));

            j++;
        }

        StartCoroutine(SpawnBonus(bonus, 0.5f, _spawnPoints[0]));
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[0]));
    }
}
