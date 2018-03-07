using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour {

	public GameObject ExplosionAsteroid;

	// Use this when objects enter collider
	void OnTriggerEnter2D (Collider2D other) 
	{
		Destroy (this.gameObject);	
	}
	
/*	// Runs when object is inside the box
	void OnTriggerStay2D (Collider2D other) 
	{

	}

	//Runs when object exits the collider box
	void OnTriggerExit2D (Collider2D other) 
	{

	}*/
}
