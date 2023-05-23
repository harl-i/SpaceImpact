//using System.Collections;
//using UnityEngine;

//public class Wave_8 : Wave
//{
//    [SerializeField] private Bonus bonus;
//    [SerializeField] private float _interval;

//    private int _enemiesCountOnWave = 8;

//    private void OnEnable()
//    {
//        StartCoroutine(StartWave());
//    }

//    private IEnumerator StartWave()
//    {
//        StartCoroutine(SpawnBonus(bonus, 0, _spawnPoints[1]));

//        yield return new WaitForSeconds(_spawnDelay);

//        for (int i = 1; i < _enemiesCountOnWave + 1; i++)
//        {
//            if (i % 2 != 0)
//            {
//                StartCoroutine(SpawnEnemy(_enemiesPool, 0, 1, _spawnPoints[0].transform.position, _moveVariant));
//            }
//            else
//            {
//                StartCoroutine(SpawnEnemy(_enemiesPool, 0, 1, _spawnPoints[2].transform.position, _moveVariant));
//                yield return new WaitForSeconds(_interval);
//            }
//        }
//    }
//}
