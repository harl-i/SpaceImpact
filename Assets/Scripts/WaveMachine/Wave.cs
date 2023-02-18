using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    [SerializeField] protected List<EnemySpawnPoint> _spawnPoints;

    public void StartWave(Wave wave)
    {
        if (enabled == false)
        {
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    public void EndWave()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
        }
    }

    public Wave GetNextWave()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetWave;
        }

        return null;
    }

    protected IEnumerator Spawn(EnemyPool enemysPool, float spawnDelay, int enemysCount, EnemySpawnPoint spawnPoint)
    {
        for (int i = 0; i < enemysCount; i++)
        {
            enemysPool.TryGetObject(out GameObject result);

            if (result != null)
            {
                result.transform.position = spawnPoint.transform.position;
                result.SetActive(true);
            }
            else
            {
                Debug.Log("Enemys pool is empty");
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    //protected IEnumerator Spawn(IObjectFromPool enemyPrefab, float spawnDelay, int enemysCount, EnemySpawnPoint spawnPoint)
    //{
    //    for (int i = 0; i < enemysCount; i++)
    //    {
    //        Instantiate(enemyPrefab.GetGameObject(), spawnPoint.transform) ;

    //        yield return new WaitForSeconds(spawnDelay);
    //    }
    //}

    //protected IEnumerator Spawn(Enemy enemyPrefab, float spawnDelay, int enemysCount)
    //{
    //    if (enemysCount < _spawnPoints.Count)
    //    {
    //        for (int i = 0; i < enemysCount; i++)
    //        {
    //            Instantiate(enemyPrefab, _spawnPoints[i].transform);

    //            yield return new WaitForSeconds(spawnDelay);
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Количество врагов слишком большое");
    //    }
    //}
}
