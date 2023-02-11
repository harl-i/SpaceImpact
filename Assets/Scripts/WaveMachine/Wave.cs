using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    [SerializeField] protected List<EnemySpawnPoint> _spawnPoints;
    [SerializeField] protected int _enemyCount;

    public int EnemyCount => _enemyCount;

    public void StartWave(Wave wave)
    {
        if (enabled == false)
        {
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(wave);
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
}
