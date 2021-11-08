using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy4Controller : MonoBehaviour
{
    public float firerate;
    private float timebtwFirerate;
    private Vector3 startpoint;
    public float speed;
    public float numberofBullets;
    public float health;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startpoint = transform.position;
        if (timebtwFirerate <= 0)
        {
            var bulpos = 360f / numberofBullets;
            var angle = 0f;

            for (var i = 0; i <= numberofBullets-1; i++)
            {
                var xdir = startpoint.x + Mathf.Sin((angle * Mathf.PI) / 180 );
                var ydir = startpoint.y + Mathf.Cos((angle * Mathf.PI) / 180 );

                var direction = new Vector3(xdir, ydir, 0f);
                var move = (direction - startpoint).normalized * speed;
                var temp = Instantiate(bullet, startpoint, transform.rotation);
                temp.GetComponent<Rigidbody2D>().AddRelativeForce((new Vector3(move.x, move.y, 0f)) * 90f, ForceMode2D.Force);
                // temp.GetComponent<EnemyBullet>().damage = 3f;
                // temp.GetComponent<EnemyBullet>()._tag = "Five";

                angle += bulpos;

                timebtwFirerate = firerate;
            }
        }
        else
        {
            timebtwFirerate -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Counters.enemiesOnBoard -= 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().PlayerHealthGain(10);
        }
    }
    public void Enemy4Health(int bulletDamage)
    {
        health -= bulletDamage;
    }
}
