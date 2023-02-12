using System.Collections;
using UnityEngine;

public class TransitionDelay : Transition
{
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        StartCoroutine(DelayBetweenWave(_delay));
    }

    private IEnumerator DelayBetweenWave(float delay)
    {
        yield return new WaitForSeconds(delay);

        NeedTransit = true;
    }
}
