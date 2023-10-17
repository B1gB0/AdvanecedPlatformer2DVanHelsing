using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bolt bolt))
        {
            Die(bolt);
        }
    }

    private void Die(Bolt bolt)
    {
        bolt.gameObject.SetActive(false);
    }
}