using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bolt bolt))
        {
            Die(collision);
        }
    }

    private void Die(Collider2D collision)
    {
        Bolt bolt = collision.GetComponent<Bolt>();
        bolt.gameObject.SetActive(false);
    }
}