public class Wave_5 : Wave
{
    private int _enemiesCount = 4;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, _enemiesCount, _spawnPoints[0].transform.position, _moveVariant));
    }
}
