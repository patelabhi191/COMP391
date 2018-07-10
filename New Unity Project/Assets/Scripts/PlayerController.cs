using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Movement Settings")]
    public float jumpForce;
	public float speed;

    [Header("Ground Check")]
    public LayerMask defineGround;
    

    private Rigidbody2D rBody;
	private Animator animator;
    private float disToGround;
    private bool isRight = true;
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {

		rBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

        disToGround = GetComponent<Collider2D>().bounds.extents.y;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        isGrounded = CheckIsGround();
        animator.SetBool("isGrounded");

        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            isGrounded = false;
        }

		float moveH = Input.GetAxis ("Horizontal");

		animator.SetFloat ("hSpeed", Mathf.Abs(moveH) * speed);

		rBody.velocity = new Vector2 (moveH, rBody.velocity.y);

		
	}

    private bool CheckIsGround()
    {
        return Physics2D.Raycast(transform.position, Vector3.down, disToGround + 0.1f, defineGround);
    }

    
}
