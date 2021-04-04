using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button btnStart;
    public UnityEngine.UI.Text resScore;
    public Rigidbody player;
    public int score = 0;
    public bool isStart = false;
    public static GameControllerScript GameController;
    // Start is called before the first frame update
    void Start()
    {
        GameController = this;
        btnStart.onClick.AddListener(delegate
        {
            this.isStart = true;
            this.menu.gameObject.SetActive(false);
            this.score = 0;
            Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        });
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score;
    }
}
