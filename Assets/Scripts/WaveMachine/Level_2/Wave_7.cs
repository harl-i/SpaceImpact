using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_7 : Wave
{
    [SerializeField] private float _interval;
    [SerializeField] private List<GameObject> _wayPointsTopLine = new List<GameObject>();
    [SerializeField] private List<GameObject> _wayPointsBottomLine = new List<GameObject>();

    private int _enemiesCountOnWave = 6;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        for (int i = 1; i < _enemiesCountOnWave + 1; i++)
        {
            if (i % 2 != 0)
            {
                StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[0].transform.position, _wayPointsTopLine));
            }
            else
            {
                StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[1].transform.position, _wayPointsBottomLine));
                yield return new WaitForSeconds(_interval);
            }

        }
    }
}
