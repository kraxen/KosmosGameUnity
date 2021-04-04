using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float MaxSpeed, MinSpeed;
    public GameObject Asteroid_Explosion;
    public GameObject Player_Explosion;
    // Start is called before the first frame update
    void Start()
    {
        var asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere;
        var speed = Random.Range(MinSpeed, MaxSpeed);
        asteroid.velocity = new Vector3(0, 0, -speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            return;
        }

        Destroy(gameObject);
        Destroy(other.gameObject);

        Instantiate(Asteroid_Explosion, transform.position, Quaternion.identity);

        if (other.tag == "Player")
        {
            Instantiate(Player_Explosion, other.transform.position, Quaternion.identity);
        }
        GameControllerScript.GameController.score += 5;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
