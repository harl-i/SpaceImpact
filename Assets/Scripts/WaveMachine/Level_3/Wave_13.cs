using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_13 : Wave
{
    [SerializeField] private List<GameObject> _wayPoints = new List<GameObject>();

    private int _enemiesCountOnWave = 3;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _wayPoints));
    }
}
