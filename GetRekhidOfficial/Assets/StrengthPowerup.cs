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
	public double spawnTimer;

	// Use this for initialization
	void Start () {
		Player1C = Player1.GetComponent<Rigidbody2D> ();
		Player2C = Player2.GetComponent<Rigidbody2D> ();
		StrPwr = GameObject.Find ("StrengthPowerup");
		Random.InitState ( System.DateTime.Now.Millisecond * 2);
		despawn ();
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;
		if (!Spawned && spawnTimer > 5) {
			spawn ();
		}
		if (Spawned) {
			Random.InitState ( System.DateTime.Now.Millisecond * 2);
			StrPwr.GetComponent<Rigidbody2D>().AddForce(new Vector3(1, Mathf.Sin(Random.value * Mathf.PI) / 2));
			if (spawnTimer > 20) {
				despawn ();
			}
		}
	}

	void despawn() {
		spawnTimer = 0;
		Spawned = false;
		StrPwr.transform.Translate (10000, -10000, 0, Space.World);
	}

	void spawn() {
		int y = (int) (Random.value * 2);
		StrPwr.transform.position = new Vector3 (0, 0);
		Player2.GetComponent<PlayerMovement> ().accel = 200;
		Player1.GetComponent<PlayerMovement> ().accel = 200;
		Spawned = true;
	}

	//10 sec
	void OnTriggerEnter2D( Collider2D collider2D ) {
		if (collider2D.gameObject.Equals (Player2)) {
			//Player1C.sharedMaterial.bounciness = 100;
			Player2C.mass = 100;
			Debug.Log ("PLAYER 1 SHOULD BE BOUNCY");
			despawn ();
		} else if (collider2D.gameObject.Equals (Player1)) {
			//Player2C.sharedMaterial.bounciness = 100;
			Player1C.mass = 100;
			Debug.Log ("PLAYER 2 SHOULD BE BOUNCY");
			despawn ();
		}
	}
}
