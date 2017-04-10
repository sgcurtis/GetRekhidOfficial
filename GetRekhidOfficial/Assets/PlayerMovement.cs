using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text winnerText;

    public float speed;	
    public float friction;
    public float accel;

    float moveHorizontal = 0;
    float moveVertical = 0;

    public bool kill = false;

    private Rigidbody2D player;
    private SpriteRenderer playerSprite;

    // Use this for initialization
    void Start () {
        keys.Add("P1 Up", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("P1 Up", "W")));
        keys.Add("P1 Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P1 Down", "S")));
        keys.Add("P1 Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P1 Left", "A")));
        keys.Add("P1 Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P1 Right", "D")));

        keys.Add("P2 Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Up", "UpArrow")));
        keys.Add("P2 Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Down", "DownArrow")));
        keys.Add("P2 Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Left", "LeftArrow")));
        keys.Add("P2 Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("P2 Right", "RightArrow")));

        winnerText.enabled = false;

        accel = 200;
        speed = 10;
        friction = 20;

        player = GetComponent<Rigidbody2D> ();
        player.drag = friction;

        playerSprite = GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate ()
    {
        if (player.tag == "Player1")
        {
            if (Input.GetKey(keys["P1 Up"]))
            {
                moveVertical = 1;
            }
            else if (Input.GetKey(keys["P1 Down"]))
            {
                moveVertical = -1;
            }
            else
            {
                moveVertical = 0;
            }
            if (Input.GetKey(keys["P1 Left"]))
            {
                moveHorizontal = -1;
            }
            else if (Input.GetKey(keys["P1 Right"]))
            {
                moveHorizontal = 1;
            }
            else
            {
                moveHorizontal = 0;
            }
        }
        else if (player.tag == "Player2")
        {
            if (Input.GetKey(keys["P2 Up"]))
            {
                moveVertical = 1;
            }
            else if (Input.GetKey(keys["P2 Down"]))
            {
                moveVertical = -1;
            }
            else
            {
                moveVertical = 0;
            }
            if (Input.GetKey(keys["P2 Left"]))
            {
                moveHorizontal = -1;
            }
            else if (Input.GetKey(keys["P2 Right"]))
            {
                moveHorizontal = 1;
            }
            else
            {
                moveHorizontal = 0;
            }

        }
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        player.AddForce(movement * accel * player.mass);

        if (kill)
        {
            playerSprite.color = Color.red;
        }
    }

    public void killPlayer()
    {
        kill = true;
        if (player.tag == "Player1")
        {
            winnerText.text = "Ureel Wins!";
        }
        else if (player.tag == "Player2")
        {
            winnerText.text = "Kuhl Wins!";
        }

        winnerText.enabled = true;
        Time.timeScale = 0;
    }
}
