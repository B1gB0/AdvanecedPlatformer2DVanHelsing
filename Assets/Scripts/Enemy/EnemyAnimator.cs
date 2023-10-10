using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    public readonly int Attack = Animator.StringToHash(nameof(Attack));
    public readonly int Idle = Animator.StringToHash(nameof(Idle));
    public readonly int Run = Animator.StringToHash(nameof(Run));

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(float speed)
    {
        if (speed == 0)
            _animator.Play(Idle);
        else
            _animator.Play(Run);
    }

    public void SetAttack()
    {
        _animator.Play(Attack);
    }
}
