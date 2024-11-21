using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] float minInterval = 5f;
    [SerializeField] float maxInterval = 8f;
    [SerializeField] float moveInDist = 8f;
    [SerializeField] float yMoveSpread = 1.5f;
    [SerializeField] GameObject enemyPrefab;
    Vector3 spawnLoc, rngShootLoc, offScreenBot, offScreenTop;
    GameObject enemyInstance;
    void Start()
    {
        Camera cam = Camera.main;
        offScreenBot = cam.ViewportToWorldPoint(new Vector2(-0.1f,0.05f));
        offScreenTop = cam.ViewportToWorldPoint(new Vector2(-0.1f,0.95f));
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
        rngShootLoc = spawnLoc;
        rngShootLoc.x += Random.Range(moveInDist - 2f, moveInDist + 2f);
        rngShootLoc.y = Mathf.Clamp(rngShootLoc.y + Random.Range(-yMoveSpread, yMoveSpread), offScreenBot.y, offScreenTop.y);
        enemyInstance = Instantiate(enemyPrefab, spawnLoc, Quaternion.identity);
        enemyInstance.GetComponent<EnemyMove>().SetShootPos(rngShootLoc);
        enemyInstance.GetComponent<EnemyMove>().SetInitPos(spawnLoc);
    }
}
