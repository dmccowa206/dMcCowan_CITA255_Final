using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] float minInterval = 5f;
    [SerializeField] float maxInterval = 8f;
    [SerializeField] GameObject enemyPrefab;
    Vector3 spawnLoc, offScreenBot, offScreenTop;
    void Start()
    {
        Camera cam = Camera.main;
        offScreenBot = cam.ViewportToWorldPoint(new Vector2(-0.1f,0));
        offScreenTop = cam.ViewportToWorldPoint(new Vector2(-0.1f,1));
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval < 0)
        {
            SpawnEnemy();
            spawnInterval = Random.Range(minInterval, maxInterval);
        }
    }
    void SpawnEnemy()
    {
        spawnLoc = new Vector3(offScreenBot.x,Random.Range(offScreenBot.y,offScreenTop.y));
        Instantiate(enemyPrefab,spawnLoc, Quaternion.identity);
    }
}
