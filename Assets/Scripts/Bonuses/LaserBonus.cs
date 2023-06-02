using UnityEngine;

public class LaserBonus : Bonus
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.PickedLaserBonus(_count);
            gameObject.SetActive(false);
        }
    }
}
