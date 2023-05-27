using System.Collections;

public class Wave_59 : Wave
{
    private int[] _orderSpawnPoints = { 0, 1, 3 };

    private void OnEnable()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        for (int i = 0; i < _orderSpawnPoints.Length; i++)
        {
            SpawnEnemy(_enemiesPool, _spawnPoints[_orderSpawnPoints[i]], _moveVariant);
        }
        yield return null;
    }
}
