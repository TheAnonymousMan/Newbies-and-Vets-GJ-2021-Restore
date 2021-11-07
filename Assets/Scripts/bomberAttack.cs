using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberAttack : MonoBehaviour
{
    private float speed = 8f;
    private GameObject player;
    void Start(){

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
    }
}
