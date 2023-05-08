using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_27 : Wave
{
    [SerializeField] private Bonus _bonus;
    [SerializeField] private List<GameObject> _wayPoints = new List<GameObject>();

    private int _enemiesCountOnWave = 9;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        StartCoroutine(SpawnBonus(_bonus, 0, _spawnPoints[0]));

        yield return new WaitForSeconds(_spawnDelay);

        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _wayPoints));
    }
}
