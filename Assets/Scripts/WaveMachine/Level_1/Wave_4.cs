public class Wave_4 : Wave
{
    private int _enemysCount = 4;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, _enemysCount, _spawnPoints[0].transform.position, _moveVariant));
    }
}
