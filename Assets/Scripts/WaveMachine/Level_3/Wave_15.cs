using System.Collections;

public class Wave_15 : Wave
{
    private int _enemiesCount = 5;

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        for (int i = 0; i < _enemiesCount; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[i], _moveVariant);
        }
        yield return null;
    }
}
