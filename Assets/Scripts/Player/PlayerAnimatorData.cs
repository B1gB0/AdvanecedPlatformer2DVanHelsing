using UnityEngine;

public class PlayerAnimatorData : MonoBehaviour
{
    public readonly int Idle = Animator.StringToHash(nameof(Idle));
    public readonly int Run = Animator.StringToHash(nameof(Run));
    public readonly int TakeOff = Animator.StringToHash(nameof(TakeOff));
    public readonly int isRunning = Animator.StringToHash(nameof(isRunning));
    public readonly int isJumping = Animator.StringToHash(nameof(isJumping));
    public readonly int Shoot = Animator.StringToHash(nameof(Shoot));
    public readonly int Attack1 = Animator.StringToHash(nameof(Attack1));
    public readonly int Attack2 = Animator.StringToHash(nameof(Attack2));
}
