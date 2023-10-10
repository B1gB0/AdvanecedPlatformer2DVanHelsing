using UnityEngine.Events;
using UnityEngine;

public class DetectionTarget : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public event UnityAction <Transform> ChangedAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            ChangedAction?.Invoke(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            ChangedAction?.Invoke(_enemy.DefaultTarget);
        }
    }
}
