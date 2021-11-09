using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 diff;
    private float rotZ;
    private Vector3 screenBounds;
    private int playerHealth;
    private bool isAlive;
    private float startBulletTimer;
    private float currentBulletTimer;

    public Image healthBar;
    public GameObject player;
    public GameObject muzzle;
    public GameObject bullet;
    public float playerSpeed;
    public float playerRotationSpeed;
    public float bulletInterval;

    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerHealth = 50;
        isAlive = true;
        startBulletTimer = Time.time;
    }

    // Function that rotates the player on their axis based on the position of the mouse
    void RotatePlayer()
    {
        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        // Calculate rotation
        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;

        Quaternion targetRotation = Quaternion.Euler(0, 0, rotZ);

        // Apply to object
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * playerRotationSpeed);
    }


    // Function that moves the player based on user input
    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // The player moves up
            transform.position = transform.position + new Vector3(0, playerSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // The player moves to the left
            transform.position = transform.position - new Vector3(playerSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // The player moves down
            transform.position = transform.position - new Vector3(0, playerSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // The player moves to the right
            transform.position = transform.position + new Vector3(playerSpeed * Time.deltaTime, 0, 0);
        }
    }

    // Function that prevents the player from going out-of-bounds
    void ClampPlayer()
    {
        if (transform.position.x + (transform.localScale.x / 2) > screenBounds.x)
        {
            transform.position = new Vector3(screenBounds.x - (transform.localScale.x / 2), transform.position.y, transform.position.z);
        }

        if (transform.position.x - (transform.localScale.x / 2) < -1 * screenBounds.x)
        {
            transform.position = new Vector3(-1 * screenBounds.x + (transform.localScale.x / 2), transform.position.y, transform.position.z);
        }

        if (transform.position.y + (transform.localScale.y / 2) > screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x, screenBounds.y - (transform.localScale.y / 2), transform.position.z);
        }

        if (transform.position.y - (transform.localScale.y / 2) < -1 * screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x, -1 * screenBounds.y + (transform.localScale.y / 2), transform.position.z);
        }
    }

    // Function that checks if the player has perished
    void PlayerDeath()
    {
        if (playerHealth <= 0)
        {
            isAlive = false;
            Flags.isPlayerAlive = false;
        }
    }

    public void PlayerHit(int damage)
    {
        playerHealth -= damage;
        float temp =  (float)playerHealth / 100;
        healthBar.fillAmount = temp;
    }

    // Update is called once per frames
    void Update()
    {
        if (isAlive)
        {
            // Rotate the player
            RotatePlayer();

            // Move the player
            MovePlayer();

            // Prevent the player from moving out-of-bounds
            ClampPlayer();
        }

        if (Input.GetMouseButton(0))
        {
            currentBulletTimer = Time.time;

            if (currentBulletTimer - startBulletTimer >= bulletInterval)
            {
                GameObject bulletTransform = Instantiate(bullet, muzzle.transform.position, transform.rotation);

                Vector3 bulletDir = muzzle.transform.up;
                bulletTransform.GetComponent<BulletController>().Setup(bulletDir);

                startBulletTimer = currentBulletTimer;
            }
        }

        // Check if the player has perished
        PlayerDeath();
        
        
    }

    public void PlayerHealthGain(int healthGain)
    {
        if (playerHealth < 100)
        {
            playerHealth += healthGain;
            if (playerHealth >= 100)
            {
                playerHealth = 100;
            }
           
            float temp =  (float)playerHealth / 100;
            healthBar.fillAmount = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy 2 Bullet")
        {
            PlayerHit(5);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemy 4 Bullet")
        {
            PlayerHit(7);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Boss Bullet")
        {
            PlayerHit(10);
            Destroy(collision.gameObject);
        }
    }
}
