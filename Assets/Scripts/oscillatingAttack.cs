using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillatingAttack : MonoBehaviour
{
    public float speed = 100f;
    public int count = 0;
    public bool change = false;

    void Update()
    {
        // Horizontal Movement
        if (count >= 0 && count <= 100 && change == false)
        {
            transform.position += new Vector3(speed * Time.deltaTime * 3, 0, 0);
            count++;
            if (count == 100)
            {
                change = true;
            }
        }
        else
        {
            transform.position += new Vector3(-speed * Time.deltaTime * 3, 0, 0);
            count--;
            if (count == 0)
            {
                change = false;
            }
        }
    }
}
