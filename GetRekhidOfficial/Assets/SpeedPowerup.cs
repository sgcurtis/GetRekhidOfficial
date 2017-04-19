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
	public double spawnTimer;

	// Use this for initialization
	void Start () {
		Player1C = Player1.GetComponent<Rigidbody2D> ();
		Player2C = Player2.GetComponent<Rigidbody2D> ();
		SpdPwr = GameObject.Find ("SpeedPowerup");
		despawn ();
	}

	// Update is called once per frame
	void Update () {
		spawnTimer += Time.deltaTime;
		if (!Spawned && spawnTimer > 5) {
			spawn ();
		}
		if (Spawned) {
			int y = Random.Range ( 1, 256 );
			int x = Random.Range ( 1, 256 );
			SpdPwr.GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Sin(x % (2 * Mathf.PI)),y % 5));
			if (spawnTimer > 20) {
				despawn ();
			}
		}
	}

	void despawn() {
		spawnTimer = 0;
		Spawned = false;
		SpdPwr.transform.Translate (10000, 10000, 0, Space.World);
	}

	void spawn() {
		int x = Random.Range ( -4, 4 );
		SpdPwr.transform.position = new Vector3 (x, -8);
		Player2.GetComponent<PlayerMovement> ().accel = 200;
		Player1.GetComponent<PlayerMovement> ().accel = 200;
		Spawned = true;
	}

	//10 sec
	void OnTriggerEnter2D( Collider2D collider2D ) {
		if (collider2D.gameObject.Equals (Player2)) {
			Player2.GetComponent<PlayerMovement>().accel = 350;
			Debug.Log ("PLAYER 1 SHOULD BE SPEEDY");
			despawn ();
		} else if (collider2D.gameObject.Equals (Player1)) {
			Player1.GetComponent<PlayerMovement>().accel = 350;
			Debug.Log ("PLAYER 2 SHOULD BE SPEEDY");
			despawn ();
		}
	}
}
