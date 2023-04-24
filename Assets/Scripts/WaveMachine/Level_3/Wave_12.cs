using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Wave_12 : Wave
{
    [SerializeField] private List<GameObject> _wayPoints = new List<GameObject>();

    private int _enemiesCountOnWave = 10;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _wayPoints));

    }
}
