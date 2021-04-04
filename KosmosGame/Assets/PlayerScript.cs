using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float MaxPositionX, MinPositionX, MaxPositionY, MinPositionY;
    public GameObject lazerShot;
    public Transform lazerGun;
    private float NextShotTime;
    public float ShotDelay;
    Rigidbody PlayerShip;
    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.GameController.isStart)
        {
            return;
        }
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        PlayerShip.velocity = new Vector3(moveHorizontal, moveVertical, 0) * speed;

        var ClampPositionX = Mathf.Clamp(PlayerShip.position.x, MinPositionX, MaxPositionX);
        var ClampPositionY = Mathf.Clamp(PlayerShip.position.y, MinPositionY, MaxPositionY);
        Vector3 vector3 = PlayerShip.position = new Vector3(ClampPositionX, ClampPositionY, 0);

        if (Input.GetButton("Fire1") && (Time.time > NextShotTime))
        {
            Instantiate(lazerShot, lazerGun.position, new Quaternion(90,0,0,90));
            NextShotTime = Time.time + ShotDelay;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") || (other.tag == "Finish"))
        {
            return;
        }
        GameControllerScript.GameController.isStart = false;
        GameControllerScript.GameController.resScore.text = "Score: " + GameControllerScript.GameController.score.ToString();
        GameControllerScript.GameController.menu.gameObject.SetActive(true);
    }
}
