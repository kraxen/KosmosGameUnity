using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float MaxSpeed, MinSpeed;
    public float MaxPositionX, MinPositionX, MaxPositionY, MinPositionY;
    public GameObject lazerShot;
    public GameObject Player_Explosion;
    private float NextShotTime;
    public float ShotDelay;
    float moveTime;
    Rigidbody enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        var speed = Random.Range(MinSpeed, MaxSpeed);
        enemy.velocity = new Vector3(0, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > moveTime)
        {
            var speed = Random.Range(MinSpeed, MaxSpeed);
            var moveHorizontal = Random.Range(-1, 2);
            var moveVertical = Random.Range(-1, 2);
            enemy.velocity = new Vector3(moveHorizontal * speed, moveVertical * speed, -speed);
            moveTime = Time.time + (float)0.5;
        }

        var ClampPositionX = Mathf.Clamp(enemy.position.x, MinPositionX, MaxPositionX);
        var ClampPositionY = Mathf.Clamp(enemy.position.y, MinPositionY, MaxPositionY);
        enemy.position = new Vector3(ClampPositionX, ClampPositionY, enemy.position.z);


        if (Time.time > NextShotTime)
        {
            Instantiate(lazerShot, transform.position, new Quaternion(0, 90, -90, 0));
            NextShotTime = Time.time + ShotDelay;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            return;
        }
        if (other.tag == "EnemyLazer")
        {
            return;
        }

        Destroy(gameObject);
        Destroy(other.gameObject);

        Instantiate(Player_Explosion, transform.position, Quaternion.identity);

        if (other.tag == "Player")
        {
            Instantiate(Player_Explosion, other.transform.position, Quaternion.identity);
        }
        GameControllerScript.GameController.score += 5;
    }
}
