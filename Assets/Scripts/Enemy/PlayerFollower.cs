using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private DetectionTarget _detectionTarget;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _detectionTarget.ChangedAction += OnChangedAction;
    }

    private void OnDisable()
    {
        _detectionTarget.ChangedAction -= OnChangedAction;
    }

    public void OnChangedAction(Transform target)
    {
        _enemy.GetTarget(target);
    }
}
