using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberAttack : MonoBehaviour
{
    private float speed = .5f;
    public Transform target;
    public GameObject player;
    // Start is called before the first frame update
    public void suicideAttack()
    {
        Debug.Log("Attacking!");
        // target = player.transform;
        // target.transform.localScale = new Vector2(0f, 0f);
        // while (this.transform.position != player.transform.position)
        // {
        //     float step = speed * Time.deltaTime;
        //     transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        // }
    }
}
