using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmittorScript : MonoBehaviour
{
    public GameObject asteroid1, asteroid2, asteroid3;
    public GameObject enemy;
    public float difficulty = 0.5f;
    private float MinDilay = 3f, MaxDilay = 5f;
    private int asteroidValue = 0;
    private float nextTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.GameController.isStart)
        {
            return;
        }

        if (Time.time > nextTime)
        {
            float posZ = transform.position.z;
            asteroidValue = (int)difficulty;
            for (int i = 0; i < asteroidValue; i++)
            {
                float posAstX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                float posAstY = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2);
                
                int e = Random.Range(0, 3);
                switch (e)
                {
                    case 0: Instantiate(asteroid1, new Vector3(posAstX, posAstY, posZ), Quaternion.identity); break;
                    case 1: Instantiate(asteroid2, new Vector3(posAstX, posAstY, posZ), Quaternion.identity); break;
                    case 2: Instantiate(asteroid3, new Vector3(posAstX, posAstY, posZ), Quaternion.identity); break;
                }      
            }
            float posX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float posY = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2);
            Instantiate(enemy, new Vector3(posX, posY, posZ), Quaternion.identity);

            nextTime = Time.time + Random.Range(MinDilay / difficulty, MaxDilay / difficulty);
            difficulty += 0.01f;
        }
    }
}
