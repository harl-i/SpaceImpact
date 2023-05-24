public class Wave_16 : Wave
{
    private void OnEnable()
    {
        SpawnEnemy(_enemiesPool, _spawnPoints[2], _moveVariant);
    }
}
