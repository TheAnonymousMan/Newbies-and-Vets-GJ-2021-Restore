using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    public GameObject bullet;
    
    public float primaryfirerate;
    private float timebtwprimary;
    
    public Transform first;
    public Transform second;
    public Transform third;

    public float rotationSpeed;
    
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        timebtwprimary = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        if (timebtwprimary <= 0)
        {
            var temp1 = Instantiate(bullet, first.position, first.rotation);
            temp1.GetComponent<Rigidbody2D>().AddRelativeForce(first.transform.up * speed * 30f, ForceMode2D.Force);
            // temp1.GetComponent<EnemyBullet>().damage = 4f;
            // temp1.GetComponent<EnemyBullet>()._tag = "Four";


            // var temp2 = Instantiate(bullet, second.position, first.rotation);
            // temp2.GetComponent<Rigidbody2D>().AddRelativeForce(second.transform.up * speed * 20f, ForceMode2D.Force);
            //
            // temp2.GetComponent<EnemyBullet>().damage = 4f;
            // temp2.GetComponent<EnemyBullet>()._tag = "Four";
            // var temp3 = Instantiate(bullet, third.position, first.rotation);
            // temp3.GetComponent<Rigidbody2D>().AddRelativeForce(third.transform.up * speed * 20f, ForceMode2D.Force);

            timebtwprimary = primaryfirerate;
        }

        else
        {
            timebtwprimary -= Time.deltaTime;
        }
    }
}
