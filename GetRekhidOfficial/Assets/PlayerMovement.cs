using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float accel;	
    public float friction;

    public bool kill = false;

    private Rigidbody2D player1;
    private SpriteRenderer player1Sprite;

    // Use this for initialization
    void Start () {
        player1 = GetComponent<Rigidbody2D> ();
        player1.drag = friction;

        player1Sprite = GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate ()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        player1.AddForce(movement * accel);

        if (kill)
        {
            player1Sprite.color = Color.red;
        }
    }

    public void killPlayer()
    {
        kill = true;
    }
}
