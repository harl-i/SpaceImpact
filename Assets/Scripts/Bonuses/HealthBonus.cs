using UnityEngine;

public class HealthBonus : Bonus
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.PickedHealthBonus(_count);
            gameObject.SetActive(false);
        }
    }
}
