using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace classes
{
    public class enemyC
    {
        public int health = 100;
        public float size = 10f;
        public void attack(int bullets, int timeInterval)
        {

        }
        public enemyC(int hp, float xyz)
        {
            this.health = hp;
            this.size = xyz;
        }
    }

    public class baseClass : MonoBehaviour
    {
        //change 'name' later to represent something better
        public GameObject cube;
        public GameObject circle;
        void Start()
        {
        }
        void Update()   
        {
            //The reason for the spawn will change
            if (Input.GetKeyDown("x"))
            {
                var bomber = new enemyC(30, Random.Range(1f, 2f));
                Debug.Log(bomber.health);
                
                // cube.transform.localScale = new Vector3(c1.size, c1.size, c1.size);
                GameObject temp = Instantiate(cube, new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
                temp.gameObject.GetComponent<bomberAttack>().suicideAttack();
            }
            
            if (Input.GetKeyDown("k"))
            {
                var hoverEnemy = new enemyC(150, 10);
                Debug.Log(hoverEnemy.health);

                GameObject temp = Instantiate(circle, new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
            }
        }
    }
}

