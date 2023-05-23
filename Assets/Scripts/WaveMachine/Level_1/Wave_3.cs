 using System.Collections;
using System.Collections.Generic;

public class Wave_3 : Wave
{
    private Dictionary<int, int> _enemyCountOnIteration = new Dictionary<int, int>()
    {
        {0, 2},
        {1, 1},
    };

    private void OnEnable()
    {
        StartCoroutine(ActivateSpawn());
    }

    private IEnumerator ActivateSpawn()
    {
        for (int i = _enemyCountOnIteration.Count; i > 0; i--)
        {
            yield return StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, 
                _enemyCountOnIteration[i - 1], _spawnPoints[i - 1].transform.position, _moveVariant));
        }
    }
}