using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, ymin, ymax;
}

public class PlayerControl : MonoBehaviour 
{

	public float speed;
    public Boundary boundary;
    public GameObject Laser;
    public Transform LaserSpawn;

    /*ublic float xmin;
     public float xmax;
     public float ymin;
     public float ymax;*/

    //private variables
    private Rigidbody2D rBody;
    public float nextFire = 0.25f;
    private float myTime = 0.0f;


    // Use this for initialization
    void Start () 
	{
        rBody = this.gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime>nextFire)
        {
            Instantiate(Laser, LaserSpawn.position, LaserSpawn.rotation);
            myTime = 0.0f;
        }
	}

	//Used when performing physics calculation
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");	//Returns between -1 and 1 when a or d pressed
		float moveVertical = Input.GetAxis("Vertical");    //Returns between -1 and 1 when w or s pressed

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
	 	Rigidbody2D rBody = this.gameObject.GetComponent<Rigidbody2D> ();
		rBody.velocity = movement*speed;
        
        /*rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, -7.9f, 3.0f),
            Mathf.Clamp(rBody.position.y, -4.5f, 4.5f));  --- Traditional Method

        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, xmin, xmax),
            Mathf.Clamp(rBody.position.y, ymin, ymax));  ---  Can be be adjusted when required*/

      rBody.position = new Vector2(
          Mathf.Clamp(rBody.position.x, boundary.xmin, boundary.xmax),
          Mathf.Clamp(rBody.position.y, boundary.ymin, boundary.ymax));

        //Debug.Log ("H= " + moveHorizontal + "V= " + moveVertical);   //indicating key pressed at console section

    }
}
