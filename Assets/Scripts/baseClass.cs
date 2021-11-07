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
        public GameObject kamikaze;
        public GameObject oscillator;
        public GameObject waitAndGo;
        void Update()   
        {
            // The reason for the spawn will change
            if (Input.GetKeyDown("x"))
            {
                // Currently changing the spawn size, easy to create as a constant
                var bomber = new enemyC(30, Random.Range(1f, 2f));
                // Debug.Log(bomber.health);
                
                GameObject temp = Instantiate(kamikaze, new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
                temp.transform.localScale = new Vector3(bomber.size, bomber.size, bomber.size);
            }
            
            if (Input.GetKeyDown("k"))
            {
                var hoverEnemy = new enemyC(150, 1);
                // Debug.Log(hoverEnemy.health);

                GameObject temp = Instantiate(oscillator, new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
                temp.transform.localScale = new Vector3(hoverEnemy.size, hoverEnemy.size, hoverEnemy.size);
            }

            if (Input.GetKeyDown("f"))
            {
                var crazy = new enemyC(100, 1);
                // Debug.Log(crazy.health);

                GameObject temp = Instantiate(waitAndGo, new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity);
                temp.transform.localScale = new Vector3(crazy.size, crazy.size, crazy.size);
            }
        }
    }
}

