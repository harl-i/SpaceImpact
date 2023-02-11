using System;
using TMPro;
using UnityEngine;

public class WaveMachine : MonoBehaviour
{
    [SerializeField] private Wave _firstWave;


    private Wave _currentWave;

    //public Wave CurrentWave => _currentWave;

    private void Start()
    {
        Reset(_firstWave);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        var nextWave = _currentWave.GetNextWave();
        if (nextWave != null)
            Transit(nextWave);
    }

    private void Reset(Wave startWave)
    {
        _currentWave = startWave;

        if (_currentWave != null)
            _currentWave.StartWave(_currentWave);
    }

    private void Transit(Wave nextWave)
    {
        if (_currentWave != null)
            _currentWave.EndWave();

        _currentWave = nextWave;

        if (_currentWave != null)
        {
            _currentWave.StartWave(_currentWave);
        }
    }
}
