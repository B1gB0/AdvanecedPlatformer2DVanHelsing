using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;
    [SerializeField] private float _speed;

    private int _numberPoint = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Transform targetPoint = _targetPoints[_numberPoint];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position)
            SetDirection();
    }

    private Vector3 SetDirection()
    {
        _numberPoint++;

        if (_numberPoint == _targetPoints.Length)
            _numberPoint = 0;

        Vector3 targetPosition = _targetPoints[_numberPoint].transform.position;
        transform.forward = targetPosition - transform.position;

        return targetPosition;
    }
}
