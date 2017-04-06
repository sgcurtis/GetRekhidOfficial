using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPowerup : MonoBehaviour {
	public GameObject Player1;
	public GameObject Player2;
	public GameObject StrPwr;
	public Rigidbody2D Player1C;
	public Rigidbody2D Player2C;
	public bool Spawned;

	// Use this for initialization
	void Start () {
		Player1C = Player1.GetComponent<Rigidbody2D> ();
		Player2C = Player2.GetComponent<Rigidbody2D> ();
		StrPwr = GameObject.Find ("StrengthPowerup");
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
		StrPwr.transform.position = new Vector3(x, y);
		Spawned = true;
	}

	//10 sec
	void OnTriggerEnter2D( Collider2D collider2D ) {
		if (collider2D.gameObject.Equals (Player2)) {
			//Player1C.sharedMaterial.bounciness = 100;
			Player2C.mass = 100;
			Debug.Log ("PLAYER 1 SHOULD BE BOUNCY");
			StrPwr.transform.position = new Vector3 (1000, 1000);
			Spawned = false;
		} else if (collider2D.gameObject.Equals (Player1)) {
			//Player2C.sharedMaterial.bounciness = 100;
			Player1C.mass = 100;
			Debug.Log ("PLAYER 2 SHOULD BE BOUNCY");
			StrPwr.transform.position = new Vector3 (1000, 1000);
			Spawned = false;
		}
	}
}
