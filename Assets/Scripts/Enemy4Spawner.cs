using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy4Spawner : MonoBehaviour
{
    public GameObject enemy4;

    public Transform first;

    public Transform second;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy4One",15f, 10f);
        InvokeRepeating("spawnEnemy4two",15f,10f);
    }

    void spawnEnemy4One()
    {
        if (first.childCount <= 0)
        {
            GameObject temp = Instantiate(enemy4, first.position, quaternion.identity);
            temp.transform.parent = first;
        }
        
    }

    void spawnEnemy4two()
    {
        if (second.childCount <= 0)
        {
            GameObject temp = Instantiate(enemy4, second.position, quaternion.identity);
            temp.transform.parent = second;
        }
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
