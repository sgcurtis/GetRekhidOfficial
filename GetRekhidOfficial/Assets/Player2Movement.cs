using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour {

    public float accel;
    public float friction;

    public bool kill = false;

    private Rigidbody2D player2;
    private SpriteRenderer player2Sprite;

    // Use this for initialization
    void Start () {
        player2 = GetComponent<Rigidbody2D>();
        player2.drag = friction;

        player2Sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2");
        float moveVertical = Input.GetAxis("Vertical2");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        player2.AddForce(movement * accel);

        if (kill)
        {
            player2Sprite.color = Color.red;
        }
    }

    public void killPlayer()
    {
        kill = true;
    }
}
