using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBoss_3 : Wave
{
    [SerializeField] private List<GameObject> _wayPoints = new List<GameObject>();

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, 1, _spawnPoints[0].transform.position, _wayPoints, true));
    }
}
