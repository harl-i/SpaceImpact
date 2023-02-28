using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_1 : Wave
{
    [SerializeField] private Bonus bonus;

    private Dictionary<int, int> _enemyCountOnIteration = new Dictionary<int, int>()
    {
        {0, 3},
        {1, 5},
        {2, 3}
    };

    private void OnEnable()
    {
        StartCoroutine(ActivateSpawn());
    }

    private IEnumerator ActivateSpawn()
    {
        for (int i = 0; i < _enemyCountOnIteration.Count; i++)
        {
            yield return StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemyCountOnIteration[i], _spawnPoints[i].transform.position, MoveVariant));
        }

        StartCoroutine(SpawnEnemy(_enemysPool, 0.15f, 1, _spawnPoints[0].transform.position, MoveVariant));
        StartCoroutine(SpawnBonus(bonus, 1f, _spawnPoints[0]));


        StartCoroutine(SpawnEnemy(_enemysPool, 2f, 1, _spawnPoints[0].transform.position, MoveVariant));
    }
}
