using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour 
{

	public float speed;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//Used when performing physics calculation
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");	//Returns between -1 and 1 when a or d pressed
		float moveVertical = Input.GetAxis("Vertical");    //Returns between -1 and 1 when w or s pressed

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
	 	Rigidbody2D rBody = this.gameObject.GetComponent<Rigidbody2D> ();
		rBody.velocity = movement*speed;

		//Debug.Log ("H= " + moveHorizontal + "V= " + moveVertical);   //indicating key pressed at console section

	}
}
