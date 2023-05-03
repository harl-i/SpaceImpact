using UnityEngine;
using UnityEngine.Events;

public class NonShootingEnemy : SpaceFlyingObject
{
    private int _collisionDamage = 1;

    public static event UnityAction<int> RewardAccrual;

    protected override void Die()
    {
        base.Die();
        RewardAccrual?.Invoke(_reward);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_collisionDamage);
            Die();
        }
    }

}
