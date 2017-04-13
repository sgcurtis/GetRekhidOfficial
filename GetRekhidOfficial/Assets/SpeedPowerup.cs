using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour {
	public GameObject Player1;
	public GameObject Player2;
	public GameObject SpdPwr;
	public Rigidbody2D Player1C;
	public Rigidbody2D Player2C;
	public bool Spawned;

	// Use this for initialization
	void Start () {
		Player1C = Player1.GetComponent<Rigidbody2D> ();
		Player2C = Player2.GetComponent<Rigidbody2D> ();
		SpdPwr = GameObject.Find ("SpeedPowerup");
		Spawned = false;
	}

	// Update is called once per frame
	void Update () {
		if (!Spawned) {
			spawn ();
		}
	}

	void spawn() {
		int x = (int) Random.value * 100;
		int y = (int) Random.value * 100;
		SpdPwr.transform.position = new Vector3(x, y);
		Spawned = true;
	}

	//10 sec
	void OnTriggerEnter2D( Collider2D collider2D ) {
		if (collider2D.gameObject.Equals (Player2)) {
			Player2.GetComponent<PlayerMovement>().accel = 500;
			Debug.Log ("PLAYER 1 SHOULD BE SPEEDY");
			SpdPwr.transform.position = new Vector3 (1000, 1000);
			Spawned = false;
		} else if (collider2D.gameObject.Equals (Player1)) {
			Player1.GetComponent<PlayerMovement>().accel = 500;
			Debug.Log ("PLAYER 2 SHOULD BE SPEEDY");
			SpdPwr.transform.position = new Vector3 (1000, 1000);
			Spawned = false;
		}
	}
}
