using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject[] SpawnLocations;

    private float timer;
    private int numberEnemies;

    int prevSpawnLocation;
    int spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;

        prevSpawnLocation = 0;
        spawnLocation = 0;

        // update this formula
        Counters.maxEnemiesOnBoard = SceneManager.GetActiveScene().buildIndex * 5;
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
            && Counters.enemiesOnBoard < Counters.maxEnemiesOnBoard)
        {
            spawnLocation = Random.Range(0, SpawnLocations.Length);

            if (spawnLocation != prevSpawnLocation)
            {
                timer = 0.0f;
                Instantiate(enemyType, SpawnLocations[spawnLocation].transform.position, Quaternion.identity);
                prevSpawnLocation = spawnLocation;

                numberEnemies += 1;
                Counters.enemiesOnBoard += 1;
            }
        }
    }
}
