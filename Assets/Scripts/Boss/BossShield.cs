using System.Collections;
using UnityEngine;

public class BossShield : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _armor = 12;
    [SerializeField] private Blink _blink;

    private int _damage = 1;
    private bool _isBroken = false;
    private bool _isApplyDamage = false;
    private bool _isNotLaunch = true;
    private bool _isCoroutineRunning = false;

    public void ApplyDamage(int damage)
    {
        _armor -= damage;
        _isApplyDamage = true;

        if (_armor <= 0)
        {
            SetParametersBeforeLaunch();
        }
    }

    private void SetParametersBeforeLaunch()
    {
        _animator.enabled = false;
        transform.parent = null;
        _isBroken = true;
        _isNotLaunch = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            enabled = false;
        }

        if (collision.gameObject.TryGetComponent(out DisableTrigger disableTrigger))
        {
            enabled = false;
        }
    }

    private void Update()
    {
        if (_isApplyDamage && _isNotLaunch)
        {
            if (_isCoroutineRunning == false)
            {
                _isCoroutineRunning = true;
                StartCoroutine(BlinkActivate());
            }

            _isApplyDamage = false;
        }

        if (_isBroken)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 6f);
        }
    }

    private IEnumerator BlinkActivate()
    {
        _blink.enabled = true;
        yield return new WaitForSeconds(_blink.BlinkingTime);
        _blink.enabled = false;
        _isCoroutineRunning = false;
    }
}
