public class Wave_16 : Wave
{
    private int _enemiesCountOnWave = 1;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _moveVariant));
    }
}
