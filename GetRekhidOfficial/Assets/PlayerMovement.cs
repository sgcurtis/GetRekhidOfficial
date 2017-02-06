using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
//Taken from Unity's 2d UFO Tutorial

	public float speed;		//Store's player's movement speed

	private Rigidbody2D rb2d;	//Store a referance to the Rigidbody2D

	// Use this for initialization
	void Start () {

		//get and store Rigidbody referance
		rb2d = GetComponent<Rigidbody2D> ();
	
	}
	
	// FixedUpdate is called at a fixed interval independent of frame rate
	//Physics code goes here
	void FixedUpdate () {

		//store current horizontal input in float moveHorizontal
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//store current vertical input in the float moveVertical
		float moveVertical = Input.GetAxis ("Vertical");

		//Ust the stored floats to creat a new Vector2 variable movement
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//call AddForce function to rigidbody and multiply by speed
		rb2d.AddForce (movement * speed);	
	}
}
