using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _minGroundNormalY = .65f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private LayerMask _layerMask;

    protected bool isFacingRight = true;
    protected bool isGrounded;
    protected Vector2 moveInput;
    protected Vector2 groundNormal;
    protected Rigidbody2D rigidbody2d;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    public Vector2 Velocity => _velocity;
    public bool IsGrounded => isGrounded;

    private void OnEnable()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(_layerMask);
        contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            _velocity.y = _jumpForce;
        }
    }

    private void FixedUpdate()
    {
        _velocity += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = moveInput.x * _speed;

        isGrounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);

        if (isFacingRight == false)
        {
            Flip();
        }
        else if (isFacingRight == true)
        {
            Flip();
        }
    }

    private void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;


        int count = rigidbody2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);

        hitBufferList.Clear();

        for (int i = 0; i < count; i++)
        {
            hitBufferList.Add(hitBuffer[i]);
        }

        for (int i = 0; i < hitBufferList.Count; i++)
        {
            Vector2 currentNormal = hitBufferList[i].normal;
            if (currentNormal.y > _minGroundNormalY)
            {
                isGrounded = true;
                if (yMovement)
                {
                    groundNormal = currentNormal;
                    currentNormal.x = 0;
                }
            }

            float projection = Vector2.Dot(_velocity, currentNormal);
            if (projection < 0)
            {
                _velocity = _velocity - projection * currentNormal;
            }

            float modifiedDistance = hitBufferList[i].distance - shellRadius;
            distance = modifiedDistance < distance ? modifiedDistance : distance;
        }

        rigidbody2d.position = rigidbody2d.position + move.normalized * distance;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        if (moveInput.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (moveInput.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
