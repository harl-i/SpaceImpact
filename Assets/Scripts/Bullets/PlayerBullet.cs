using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ShootingEnemy shootingEnemy) || 
            collision.TryGetComponent(out NonShootingEnemy nonShootingEnemy))
        {
            shootingEnemy.ApplyDamage(_damage);
            ReturnToPool();
        }

        if (collision.TryGetComponent(out RightTrigger rightTrigger))
        {
            ReturnToPool();
        }

        if (collision.TryGetComponent(out Rocket rocket))
        {
            if (rocket.SenderType == RocketSender.Boss)
            {
                ReturnToPool();
            }
        }
    }
}
