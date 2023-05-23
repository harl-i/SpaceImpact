public class Wave_12 : Wave
{
    private int _enemiesCountOnWave = 10;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _moveVariant));
    }
}
