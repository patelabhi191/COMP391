using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5;

	private Rigidbody2D rBody;
	private Animator animator;

	// Use this for initialization
	void Start () {

		rBody = GetComponent<Rigidbody2D>;
		animator = GetComponent<Animator>;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveH = Input.GetAxis ("Horizontal");

		animator.SetFloat ("hSpeed", Mathf.Abs(moveH));

		rBody.velocity = new Vector2 (moveH, rBody.velocity.y);
		
	}
}
