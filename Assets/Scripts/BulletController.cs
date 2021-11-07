using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 screenBounds;
    private Vector3 bulletDir;

    public float bulletSpeed;

    [SerializeField] private string target;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void Setup(Vector3 bulletDir)
    {
        this.bulletDir = bulletDir;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -1 * screenBounds.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > screenBounds.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -1 * screenBounds.y)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > screenBounds.y)
        {
            Destroy(gameObject);
        }

        transform.position += new Vector3(bulletDir.x * bulletSpeed * Time.deltaTime, bulletDir.y * bulletSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
