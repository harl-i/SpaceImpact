public class Wave_25 : Wave
{
    private int _enemiesCountOnWave = 5;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _moveVariant));
    }
}
