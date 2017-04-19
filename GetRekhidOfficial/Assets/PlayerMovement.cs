using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public float speed;	
    public float friction;
    public float accel;

    float moveHorizontal = 0;
    float moveVertical = 0;

    public bool kill = false;
    public Text winnerText;
    public Canvas winnerBox;

    private Rigidbody2D player;
    private SpriteRenderer playerSprite;


    public AudioSource[] sounds;
    public AudioSource pushSound;
    public AudioSource dieSound;
    public AudioSource kuhlWin;
    public AudioSource kuhlLose;

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

        accel = 200;
        speed = 10;
        friction = 20;

        player = GetComponent<Rigidbody2D>();
        player.drag = friction;

        playerSprite = GetComponent<SpriteRenderer>();

        winnerBox.enabled = false;
        winnerText.text = "";

        sounds = GetComponents<AudioSource>();

        pushSound = sounds[0];
        dieSound = sounds[1]; ;
        kuhlWin = sounds[2]; ;
        kuhlLose = sounds[3]; ;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2")
        {
            pushSound.Play();
        }
        else if (col.gameObject.tag == "Ring")
        {
            dieSound.Play();
        }
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
            winnerBox.enabled = true;

            
            if (player.tag == "Player1")
            {
                kuhlLose.Play();
                winnerText.text = "Ureel Wins!";
            }
            else if (player.tag == "Player2")
            {
                kuhlWin.Play();
                winnerText.text = "Kuhl Wins!";
            }
            Time.timeScale = 0;
        }
    }

    public void killPlayer()
    {
        kill = true;
    }
}
