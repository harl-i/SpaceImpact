public class Wave_22 : Wave
{
    private int _enemiesCountOnWave = 8;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, _enemiesCountOnWave, _spawnPoints[0].transform.position, _moveVariant));
    }
}
