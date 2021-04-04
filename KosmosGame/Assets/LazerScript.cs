using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public float speed;
    public GameObject Player_Explosion;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody>().position.z > 160)
        {
            Destroy(gameObject);
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
            Instantiate(Player_Explosion, other.transform.position, Quaternion.identity);
        }
    }
}
