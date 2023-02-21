using UnityEngine;
using UnityEngine.Events;

public class NonShootingEnemy : SpaceFlyingObject
{
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
            player.ApplyDamage();
            Die();
        }
    }

}
