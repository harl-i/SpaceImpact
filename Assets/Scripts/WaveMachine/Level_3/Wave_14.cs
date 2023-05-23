//using System.Collections;
//using UnityEngine;

//public class Wave_14 : Wave
//{
//    [SerializeField] private Bonus _bonus;

//    private int _enemiesCountOnIteration = 3;
//    private int _iterations = 3;

//    private void OnEnable()
//    {
//        StartCoroutine(StartWave());
//    }

//    private IEnumerator StartWave()
//    {
//        StartCoroutine(SpawnBonus(_bonus, 0, _spawnPoints[1]));

//        yield return new WaitForSeconds(_spawnDelay);

//        for (int i = 0; i < _iterations; i++)
//        {
//            for (int j = 0; j < _enemiesCountOnIteration; j++)
//            {
//                if (j % 2 == 0)
//                {
//                    StartCoroutine(SpawnEnemy(_enemiesPool, 1.7f, 1, _spawnPoints[j].transform.position, _moveVariant));
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
