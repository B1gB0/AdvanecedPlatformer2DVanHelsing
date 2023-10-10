using System.Collections;
using UnityEngine;

public class Spawner : EnemyPool
{
    [SerializeField] Player _player;
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;

    private bool isWork = true;

    private void Start()
    {
        Initialize(_enemy);
        StartCoroutine(SpawnEnemy());
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        while(isWork)
        {
            if (TryGetEnemy(out Enemy enemyPrefab))
            {
                SetEnemy(enemyPrefab, transform.position);
                _enemy = enemyPrefab;
                _enemy.GetTarget(_target);
                _enemy.GetDefaultTarget(_target);
                _enemy.GetPlayer(_player);

                yield return waitForSeconds;
            }
        }
    }
}