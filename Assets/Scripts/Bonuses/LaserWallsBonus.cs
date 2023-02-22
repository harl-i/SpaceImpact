using UnityEngine;

public class LaserWallsBonus : Bonus
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.PickedLaserWallBonus(_count);
            gameObject.SetActive(false);
        }
    }
}
