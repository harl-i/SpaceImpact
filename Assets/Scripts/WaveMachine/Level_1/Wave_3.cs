public class Wave_3 : Wave
{
    private int _enemysCount = 2;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemy(_enemysPool, _spawnDelay, _enemysCount, _spawnPoints[0]));
    }
}