using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    [SerializeField] protected float _spawnDelay;
    [SerializeField] protected float _enemySpeed;
    [SerializeField] protected EnemyPool _enemysPool;
    [SerializeField] protected List<SpawnPoint> _spawnPoints;
    [SerializeField] protected MoveVariants MoveVariant;

    protected const string LinearMove = "LinearMove";
    protected const string ChaoticMove = "ChaoticMove";
    protected const string PointsMove = "PointsMove";

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

    protected IEnumerator SpawnEnemy(EnemyPool enemysPool, float spawnDelay, int enemysCount, Vector3 spawnPoint, MoveVariants moveVariants)
    {
        for (int i = 0; i < enemysCount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);

            enemysPool.TryGetObject(out GameObject result);

            if (result != null)
            {
                result.GetComponent<MoveSwitcher>().ActivateMoveVariant(moveVariants, _enemySpeed);
                result.transform.position = spawnPoint;
                result.SetActive(true);
            }
            else
            {
                Debug.Log("Enemys pool is empty");
            }
        }
    }

    protected IEnumerator SpawnEnemy(EnemyPool enemysPool, float spawnDelay, int enemysCount, Vector3 spawnPoint, List<GameObject> waypoints)
    {
        for (int i = 0; i < enemysCount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);

            enemysPool.TryGetObject(out GameObject result);

            if (result != null)
            {
                result.GetComponent<MoveSwitcher>().ActivateMoveVariant(MoveVariants.Points, _enemySpeed);
                result.GetComponent<PointsMove>().SetPoints(waypoints);
                result.transform.position = spawnPoint;
                result.SetActive(true);
            }
            else
            {
                Debug.Log("Enemys pool is empty");
            }
        }
    }

    protected IEnumerator SpawnEnemy(EnemyPool enemysPool, float spawnDelay, int enemysCount, Vector3 spawnPoint, List<GameObject> waypoints, bool isLooped)
    {
        for (int i = 0; i < enemysCount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);

            enemysPool.TryGetObject(out GameObject result);

            if (result != null && isLooped == true)
            {
                result.GetComponent<MoveSwitcher>().ActivateMoveVariant(MoveVariants.Patrol, _enemySpeed);
                result.GetComponent<PatrolMove>().SetPoints(waypoints);
                result.transform.position = spawnPoint;
                result.SetActive(true);
            }
            else
            {
                Debug.Log("Enemys pool is empty");
            }
        }
    }

    protected IEnumerator SpawnBonus(Bonus bonus, float spawnDelay, SpawnPoint spawnPointPosition)
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(bonus, spawnPointPosition.transform);
    }
}