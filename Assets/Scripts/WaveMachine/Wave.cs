using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    [SerializeField] protected float _spawnDelay;
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

            switch (MoveVariant)
            {
                case MoveVariants.Linear:
                    AddComponent(LinearMove);
                    break;
                case MoveVariants.Chaotic:
                    AddComponent(ChaoticMove);
                    break;
                case MoveVariants.Points:
                    AddComponent(PointsMove);
                    break;
                default:
                    break;
            }

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }

    private void AddComponent(string componentType)
    {
        var type = Type.GetType(componentType);

        if (type != null)
        {
            foreach (var enemy in _enemysPool.Pool)
            {
                enemy.AddComponent(type);
            }

        }
    }

    private void RemoveComponent(string componentType)
    {
        var type = Type.GetType(componentType);

        if (type != null)
        {
            foreach (var enemy in _enemysPool.Pool)
            {
                Destroy(enemy.GetComponent(type));
            }
        }
    }

    public void EndWave()
    {
        switch (MoveVariant)
        {
            case MoveVariants.Linear:
                RemoveComponent(LinearMove);
                break;
            case MoveVariants.Chaotic:
                RemoveComponent(ChaoticMove);
                break;
            case MoveVariants.Points:
                RemoveComponent(PointsMove);
                break;
            default:
                break;
        }

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

    protected IEnumerator SpawnEnemy(EnemyPool enemysPool, float spawnDelay, int enemysCount, SpawnPoint spawnPoint)
    {
        for (int i = 0; i < enemysCount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);

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
        }
    }

    protected IEnumerator SpawnEnemy(EnemyPool enemysPool, float spawnDelay, int enemysCount, SpawnPoint spawnPoint, List<GameObject> waypoints)
    {
        for (int i = 0; i < enemysCount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);

            enemysPool.TryGetObject(out GameObject result);

            if (result != null)
            {
                result.GetComponent<PointsMove>().SetPoints(waypoints);
                result.transform.position = spawnPoint.transform.position;
                result.SetActive(true);
            }
            else
            {
                Debug.Log("Enemys pool is empty");
            }
        }
    }

    protected IEnumerator SpawnBonus(Bonus bonus, float spawnDelay, SpawnPoint spawnPoint)
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(bonus, spawnPoint.transform);
    }
}

public enum MoveVariants
{
    Linear,
    Chaotic,
    Points
}
