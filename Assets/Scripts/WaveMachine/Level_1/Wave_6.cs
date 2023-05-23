using System.Collections;
using UnityEngine;

public class Wave_6 : Wave
{
    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        StartCoroutine(SpawnEnemy(_enemiesPool, 0, 1, _spawnPoints[0].transform.position, MoveVariants.Linear));

        yield return new WaitForSeconds(3.5f);

        StartCoroutine(SpawnEnemy(_enemiesPool, 0, 1, _spawnPoints[1].transform.position, MoveVariants.Linear));

        yield return new WaitForSeconds(1f);

        StartCoroutine(SpawnEnemy(_enemiesPool, 0, 1, _spawnPoints[0].transform.position, MoveVariants.Linear));

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(SpawnEnemy(_enemiesPool, 0, 1, _spawnPoints[2].transform.position, MoveVariants.Linear));

        yield return null;
    }
}
