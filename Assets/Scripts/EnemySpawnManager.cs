using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyType;

    [SerializeField]
    private float TimeBetweenSpawn;

    [SerializeField]
    private int maxEnemies;

    [SerializeField]
    private GameObject EnemySpawner;

    private float timer;
    private int numberEnemies;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        timer += Time.deltaTime;

        if (timer >= TimeBetweenSpawn
        && numberEnemies <= maxEnemies
        && Counters.enemiesOnBoard <= Counters.maxEnemiesOnBoard)
        {
            timer = 0.0f;
            Instantiate(enemyType, EnemySpawner.transform.position, Quaternion.identity);
            numberEnemies += 1;
        }
    }
}
