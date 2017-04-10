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
        col.gameObject.GetComponent<PlayerMovement>().killPlayer();

    }
}
