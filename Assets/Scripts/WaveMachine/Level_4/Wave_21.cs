using System.Collections;
using UnityEngine;

public class Wave_21 : Wave
{
    [SerializeField] private Bonus _bonus;
    private int _enemiesCountOnWave = 7;


    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        StartCoroutine(SpawnBonus(_bonus, 0, _spawnPoints[1]));

        int[] spawnPointOrder = { 0, 1, 2, 1 };
        int spawnOrderIndex = 0;

        for (int i = 0; i < _enemiesCountOnWave; i++)
        {
            int pointIndex = spawnPointOrder[spawnOrderIndex];
            spawnOrderIndex++;

            if (spawnOrderIndex >= spawnPointOrder.Length)
            {
                spawnOrderIndex = 0;
            }

            StartCoroutine(SpawnEnemy(_enemysPool, 0, 1, _spawnPoints[pointIndex].transform.position, MoveVariant));


            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
