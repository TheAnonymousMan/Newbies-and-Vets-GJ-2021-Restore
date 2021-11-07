using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeController : MonoBehaviour
{
    private int health;
    private int damage;
    private Rigidbody2D rb;

    [SerializeField] private GameObject target;
    [SerializeField] private float kamikazeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 20;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDistance = target.transform.position - transform.position;
        targetDistance.Normalize();

        rb.MovePosition((Vector3)transform.position + (targetDistance * kamikazeSpeed * Time.deltaTime));

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void KamikazeHit(int bulletDamage)
    {
        health -= bulletDamage;
        Debug.Log(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerController>().PlayerHit(damage);
        }
    }
}
