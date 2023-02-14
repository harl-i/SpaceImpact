using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage();
            ReturnToPool();
        }

        if (collision.TryGetComponent(out RightTrigger rightTrigger))
        {
            ReturnToPool();
        }
    }
}
