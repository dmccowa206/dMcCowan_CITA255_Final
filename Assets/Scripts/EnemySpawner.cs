using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] float minInterval = 5f;
    [SerializeField] float maxInterval = 8f;

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval < 0)
        {
            SpawnEnemy();
            spawnInterval = Random.Range(minInterval, maxInterval);
        }
    }
    GameObject enemyPrefab;
    void SpawnEnemy()
    {
    }
}
