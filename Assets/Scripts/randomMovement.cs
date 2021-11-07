using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMovement : MonoBehaviour
{

    public float speed = .00005f;

    // Update is called once per frame
    void Update()
    {
        int dec = Random.Range(1,5);
        // Debug.Log(dec);
        Debug.Log(transform.position);
        switch(dec)
        {
            case 1:
            // Debug.Log("1");
            for (int i = 0; i < 1000; i++)
                transform.position += new Vector3((speed * Time.deltaTime)/100, 0f, 0f);                
            break;

            case 2:
            // Debug.Log("2");
            for (int i = 0; i < 1000; i++)
                transform.position += new Vector3(-(speed * Time.deltaTime)/100, 0f, 0f);
            break;

            case 3:
            // Debug.Log("3");
            for (int i = 0; i < 1000; i++)
                transform.position += new Vector3(0f, (speed * Time.deltaTime)/100, 0f);
            break;

            case 4:
            // Debug.Log("4");6
            for (int i = 0; i < 1000; i++)
                transform.position += new Vector3(0f, -(speed * Time.deltaTime)/100, 0f);
            break;

            default:
            break;
        }
        Debug.Log(speed * Time.deltaTime);
        Debug.Log(transform.position);
        if (gameObject.transform.position.x <= -10)
        {
            // Debug.Log("changed");
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }            
        else if (gameObject.transform.position.x >= 10)
        {
            // Debug.Log("changed");
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }

        if (gameObject.transform.position.y <= -5)
        {
            // Debug.Log("changed");
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }            
        else if (gameObject.transform.position.y >= 5)
        {
            // Debug.Log("changed");
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
        // Debug.Log(transform.position);
   }
}
