using System.Collections;
using UnityEngine;

public class Wave_19 : Wave
{
    private int _enemiesCount = 5;

    private void OnEnable()
    {
        StartCoroutine(Startwave());
    }

    private IEnumerator Startwave()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _enemiesCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[3], _moveVariant);
            yield return delay;
        }
    }
}
