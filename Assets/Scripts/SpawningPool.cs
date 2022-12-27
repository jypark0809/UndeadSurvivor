using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    int _enemyCount = 0;
    int _reserveCount = 0;

    [SerializeField]
    int _maxEnemyCount = 0;

    Transform[] _spawnPoint;

    float _spawnTime = 1.0f;

    public void AddEnemyCount(int value) { _enemyCount += value; }
    public void SetMaxEnemyCount(int count) { _maxEnemyCount = count; }

    void Start()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
        Managers.Game.OnSpawnEvent -= AddEnemyCount;
        Managers.Game.OnSpawnEvent += AddEnemyCount;
    }

    void Update()
    {
        while (_enemyCount + _reserveCount < _maxEnemyCount)
        {
            StartCoroutine("ReserveSpawn");
        }
    }

    IEnumerator ReserveSpawn()
    {
        _reserveCount++;
        yield return new WaitForSeconds(_spawnTime);

        GameObject enemy = Managers.Game.Spawn(Define.WorldObject.Enemy, "Enemy/Enemy0");
        enemy.transform.position = _spawnPoint[Random.Range(1, _spawnPoint.Length)].position;

        _reserveCount--;
    }
}
