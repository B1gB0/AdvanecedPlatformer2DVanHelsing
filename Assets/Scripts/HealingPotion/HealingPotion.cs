using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    private float _health = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.AddHealth(_health);

            gameObject.SetActive(false);
        }
    }
}
