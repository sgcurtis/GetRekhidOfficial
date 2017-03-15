using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;	
    public float friction;

    float moveHorizontal = 0;
    float moveVertical = 0;

    public bool kill = false;

    private Rigidbody2D player;
    private SpriteRenderer playerSprite;

    // Use this for initialization
    void Start () {
        speed = 20;
        friction = 1;

        player = GetComponent<Rigidbody2D> ();
        player.drag = friction;

        playerSprite = GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate ()
    {
        if (player.tag == "Player1")
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else if (player.tag == "Player2")
        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        player.velocity = movement * speed;

        if (kill)
        {
            playerSprite.color = Color.red;
        }
    }

    public void killPlayer()
    {
        kill = true;
    }
}
