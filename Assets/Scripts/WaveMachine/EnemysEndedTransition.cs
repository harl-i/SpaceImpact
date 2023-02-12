using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysEndedTransition : Transition
{
    protected override void OnEnemyDying()
    {
        _currentWaveEnemyCount--;
        if (_currentWaveEnemyCount <= 0)
        {
            NeedTransit = true;
        }
    }
}
