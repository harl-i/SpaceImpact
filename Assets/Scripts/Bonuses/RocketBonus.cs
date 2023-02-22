using UnityEngine;

public class RocketBonus : Bonus
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.PickedRocketBonus(_count);
            gameObject.SetActive(false);
        }
    }
}
