//using System.Collections;
//using UnityEngine;

//public class Wave_28 : Wave
//{
//    private int _enemiesCountOnIteration = 3;
//    private int _iterations = 2;

//    private void OnEnable()
//    {
//        StartCoroutine(StartWave());
//    }

//    private IEnumerator StartWave()
//    {
//        for (int i = 0; i < _iterations; i++)
//        {
//            for (int j = 0; j < _enemiesCountOnIteration; j++)
//            {
//                if (j % 2 == 0)
//                {
//                    StartCoroutine(SpawnEnemy(_enemiesPool, 1.2f, 1, _spawnPoints[j].transform.position, _moveVariant));
//                }
//                else
//                {
//                    StartCoroutine(SpawnEnemy(_enemiesPool, 0, 1, _spawnPoints[j].transform.position, _moveVariant));
//                }
//            }

//            yield return new WaitForSeconds(_spawnDelay);
//        }
//    }
//}
