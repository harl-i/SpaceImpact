//using System.Collections;
//using UnityEngine;

//public class Wave_29 : Wave
//{
//    private int _enemiesCountOnWave = 10;

//    private void OnEnable()
//    {
//        StartCoroutine(StartWave());
//    }

//    private IEnumerator StartWave()
//    {
//        for (int i = 1; i < _enemiesCountOnWave + 1; i++)
//        {
//            if (i % 2 != 0)
//            {
//                StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, 1, _spawnPoints[0].transform.position, _moveVariant));
//            }
//            else
//            {
//                StartCoroutine(SpawnEnemy(_enemiesPool, _spawnDelay, 1, _spawnPoints[1].transform.position, _moveVariant));
//                yield return new WaitForSeconds(_spawnDelay);
//            }

//        }
//    }
//}
