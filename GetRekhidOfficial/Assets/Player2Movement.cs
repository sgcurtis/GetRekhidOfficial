using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour {

    public float accel;
    public float friction;

    private Rigidbody2D player2;

    // Use this for initialization
    void Start () {
        player2 = GetComponent<Rigidbody2D>();
        player2.drag = friction;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2");
        float moveVertical = Input.GetAxis("Vertical2");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        player2.AddForce(movement * accel);
    }
}
