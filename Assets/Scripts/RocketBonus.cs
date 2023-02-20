using UnityEngine;

public class RocketBonus : Bonus
{
    private int _rocketsCount = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.PickedRocketBonus(_rocketsCount);
            gameObject.SetActive(false);
        }
    }
}
