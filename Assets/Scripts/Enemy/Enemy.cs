using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : Health
{
    [SerializeField] private float _reward;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _delay;

    [SerializeField] private Transform _healthBarPoint;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Canvas _canvas;

    private EnemyAnimator _enemyAnimator;
    private Transform _defaultTarget;
    private Transform _target;
    private Player _player;

    private bool isAttack = false;
    private float _lastAttackTime;
    
    private Camera _camera;

    public Transform DefaultTarget => _defaultTarget;

    private void Awake()
    {
        _camera = Camera.main;
        _canvas.worldCamera = _camera;
        _healthBar.GetHealth(this);
    }

    private void Start()
    {
        CurrentHealth = StartHealth;
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            isAttack = true;
        }
    }

    private void Update()
    {
        if(isAttack == false)
        {
            _enemyAnimator.Move(_speed);
            transform.position = Vector3.MoveTowards
            (transform.position,_target.position, _speed * Time.deltaTime);
        }
        else if(isAttack == true)
        {
            if(_lastAttackTime < 0)
            {
                _enemyAnimator.SetAttack();
                _player.ApplyDamage(_damage);
                _lastAttackTime = _delay;
            }

            _lastAttackTime -= Time.deltaTime;
        }

        Die();
        Flip();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            isAttack = false;
        }
    }

    private void LateUpdate()
    {
        _healthBar.transform.position = _healthBarPoint.transform.position;
    }

    public void ApplyDamage(float damage)
    {
        TargetHealth = CurrentHealth - damage;
        this.OnChangeHealth(CurrentHealth, TargetHealth, StartHealth);
        CurrentHealth = TargetHealth;
    }

    public void GetTarget(Transform target)
    {
        _target = target;
    }

    public void GetPlayer(Player player)
    {
        _player = player;
    }

    public void GetDefaultTarget(Transform defaultTarget)
    {
        _defaultTarget = defaultTarget;
    }

    private void Flip()
    {
        if (transform.position.x <= _target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x >= _target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Die()
    {
        if (CurrentHealth < 0)
        {
            _player.AddMoney(_reward);
            gameObject.SetActive(false);
        }
    }
}