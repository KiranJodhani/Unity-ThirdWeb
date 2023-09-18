using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;

    [SerializeField] private Enemy _enemyPrefab = null;

    private Enemy _lastSpawned = null;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

  public  void SpawnEnemy()
    {
        _lastSpawned = Instantiate( _enemyPrefab, _spawnPoint.position, _spawnPoint.rotation );
    }
}
