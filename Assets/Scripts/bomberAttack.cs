using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberAttack : MonoBehaviour
{
    private float speed = 1f;
    public GameObject player;
    
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
    }
}
