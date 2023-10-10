using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : PlayerAnimatorData
{
    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {
        if (Input.GetMouseButtonDown(0) && _playerMovement.Velocity.x == 0)
        {
            _animator.SetTrigger(Shoot);
        }

        if (Input.GetKeyDown(KeyCode.E) && _playerMovement.Velocity.x == 0)
        {
            _animator.SetTrigger(Attack1);
        }

        if (Input.GetKeyDown(KeyCode.Q) && _playerMovement.Velocity.x == 0)
        {
            _animator.SetTrigger(Attack2);
        }

        if (_playerMovement.Velocity.x == 0)
        {
            _animator.SetBool(isRunning, false);
        }
        else
        {
            _animator.SetBool(isRunning, true);
        }

        if (Input.GetKey(KeyCode.Space) && _playerMovement.IsGrounded)
        {
            _animator.SetTrigger(TakeOff);
        }

        if (_playerMovement.IsGrounded == true)
        {
            _animator.SetBool(isJumping, false);
        }
        else
        {
            _animator.SetBool(isJumping, true);
        }
    }
}
