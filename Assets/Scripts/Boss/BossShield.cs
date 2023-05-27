using UnityEngine;

public class BossShield : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _armor = 12;
    private bool isBroken = false;

    private const string IsShieldBroken = "isShieldBroken";

    public void ApplyDamage(int damage)
    {
        _armor -= damage;

        if (_armor <= 0)
        {
            isBroken = true;
        }
    }

    private void Update()
    {
        if (isBroken)
        {
            transform.SetParent(null);
            transform.Translate(Vector2.left * 4f * Time.deltaTime);
        }
    }
}
