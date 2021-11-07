using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    Vector3 dirtolook;
    Transform player;

    public GameObject bullet;

    public float health;

    public float speed;
    public float bulletSpeed;
    private float timebtwprimary;
    public float primaryfirerate;
    public float stopdistance;
    public float backdistance;
    public Transform muzzle;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timebtwprimary = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dirtolook = (player.position - transform.position).normalized;
        LookPlayer();
        if (Vector2.Distance(transform.position, player.position) > stopdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stopdistance && Vector2.Distance(transform.position, player.position) < backdistance)
        {
            transform.position = this.transform.position;

        }
        else if (Vector2.Distance(transform.position, player.position) < backdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }

        if (timebtwprimary <= 0)
        {
            var temp = Instantiate(bullet, muzzle.position, quaternion.identity);
            var bulletDir = muzzle.transform.up;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletDir.x, bulletDir.y, 0f) * bulletSpeed;
            // temp.GetComponent<EnemyBullet>().damage = 2f;
            // temp.GetComponent<EnemyBullet>()._tag = "One";
            timebtwprimary = primaryfirerate;
        }
        else
        {
            timebtwprimary -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Counters.enemiesOnBoard -= 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerHealthGain(3);
        }
    }

    void LookPlayer()
    {
        var rot = Quaternion.LookRotation(Vector3.forward, -dirtolook);
        rot.x = rot.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 8f * Time.deltaTime);
    }

    public void Enemy2Health(int bulletDamage)
    {
        health -= bulletDamage;
    }
}
