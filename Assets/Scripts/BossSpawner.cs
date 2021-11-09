using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;
    public Transform location;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("bossSpawn",10f);
    }

    void bossSpawn()
    {
        Instantiate(boss, location.position, quaternion.identity);
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
