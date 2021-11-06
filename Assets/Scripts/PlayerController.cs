using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    //public float radius;
    //public float radiusSpeed;
    //public float rotationSpeed;

    //private Transform center;
    //private Vector3 desiredPos;

    private Vector3 mousePosition;
    private Vector3 diff;
    private float rotZ;
    private Vector3 screenBounds;
    private int playerHealth;

    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        //playerHealth = 100;
    }

    // Function that rotates the player on their axis based on the position of the mouse
    void RotatePlayer()
    {
        diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        // Calculate rotation
        rotZ = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;

        // Apply to object
        transform.rotation = Quaternion.Euler(0f,0f,rotZ);
    }

    // Function that moves the player based on user input
    void MovePlayer()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // The player moves up
            transform.position = transform.position + new Vector3(0,playerSpeed * Time.deltaTime,0);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // The player moves to the left
            transform.position = transform.position - new Vector3(playerSpeed * Time.deltaTime,0,0);
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // The player moves down
            transform.position = transform.position - new Vector3(0,playerSpeed * Time.deltaTime,0);
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // The player moves to the right
            transform.position = transform.position + new Vector3(playerSpeed * Time.deltaTime,0,0);
        }
    }

    // Function that prevents the player from going out-of-bounds
    void ClampPlayer()
    {
        if(transform.position.x + (transform.localScale.x / 2) > screenBounds.x)
        {
            transform.position = new Vector3(screenBounds.x - (transform.localScale.x / 2), transform.position.y,transform.position.z);
        }

        if(transform.position.x - (transform.localScale.x / 2) < -1 * screenBounds.x)
        {
            transform.position = new Vector3(-1 * screenBounds.x + (transform.localScale.x / 2), transform.position.y,transform.position.z);
        }

        if(transform.position.y + (transform.localScale.y / 2) > screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x,screenBounds.y - (transform.localScale.y / 2),transform.position.z);
        }

        if(transform.position.y - (transform.localScale.y / 2) < -1 * screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x,-1 * screenBounds.y + (transform.localScale.y / 2), transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the player
        RotatePlayer();

        // Move the player
        MovePlayer();

        // Prevent the player from moving out-of-bounds
        ClampPlayer();
    }
}
