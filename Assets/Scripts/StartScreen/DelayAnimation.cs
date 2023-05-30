using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DelayAnimation : MonoBehaviour
{
    [SerializeField] private float _delay;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(EnabledAnimatorWithDelay(_delay));
    }

    private IEnumerator EnabledAnimatorWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animator.enabled = true;
    }
}
