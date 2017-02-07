﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float accel;	
    public float friction;

    private Rigidbody2D player1;

    // Use this for initialization
    void Start () {
        player1 = GetComponent<Rigidbody2D> ();
        player1.drag = friction;
    }
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        player1.AddForce(movement * accel);
	}
}
