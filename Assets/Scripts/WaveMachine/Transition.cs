using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private Wave _targetWave;

    public Wave TargetWave => _targetWave;

    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
