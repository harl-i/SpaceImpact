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
        SpawnEnemy(_enemiesPool, _spawnPoints[0], MoveVariants.Linear);

        yield return new WaitForSeconds(3.5f);

        SpawnEnemy(_enemiesPool, _spawnPoints[1], MoveVariants.Linear);

        yield return new WaitForSeconds(1f);

        SpawnEnemy(_enemiesPool, _spawnPoints[0], MoveVariants.Linear);

        yield return new WaitForSeconds(1.5f);

        SpawnEnemy(_enemiesPool, _spawnPoints[4], MoveVariants.Linear);
    }
}
