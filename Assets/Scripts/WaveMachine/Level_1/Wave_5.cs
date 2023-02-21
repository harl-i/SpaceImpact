using System.Collections.Generic;
using UnityEngine;

public class Wave_5 : Wave
{
    [SerializeField] private List<GameObject> _wavePoints = new List<GameObject>();

    private int _enemysCount = 3;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemysCount, _spawnPoints[0], _wavePoints));
    }
}
