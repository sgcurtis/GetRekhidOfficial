using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            col.gameObject.GetComponent<PlayerMovement>().killPlayer();
            Debug.Log("PLAYER1");
            
        }
        else if (col.gameObject.tag == "Player2")
        {
            col.gameObject.GetComponent<Player2Movement>().killPlayer();
            Debug.Log("PLAYER2");
        }
    }
}
