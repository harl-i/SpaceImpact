public class Wave_33 : Wave
{
    private void OnEnable()
    {
        SpawnEnemy(_enemiesPool, _spawnPoints[2], _moveVariant);
    }
}
