using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;
    float vertical, horizontal;
    public int lives;
    public Text live;
    public float speed;
    public GameObject endP1;
	Animator anim;
	public AudioSource Born;
    public GameObject gameOver;

	private float xaxis;
	private float yaxis;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		anim.SetFloat("y", 0f);
		anim.SetFloat("x", 0f);
        //lives = 3;
        //PlayerPrefs.SetInt("Lives", lives);
        lives = PlayerPrefs.GetInt("Lives",3);
        if(lives == 0)
        {
            lives = 3;
        }
        live.text = "Lives: " + lives + "  ";
    }
	
	// Update is called once per frame
	void Update () 
	{
	}

    private void FixedUpdate()
    {
		xaxis = Input.GetAxis ("Horizontal");
		yaxis = Input.GetAxis ("Vertical");	
		vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
		anim.SetFloat("x", xaxis);
		anim.SetFloat("y", yaxis);
        rb.velocity = new Vector2(horizontal, vertical) * speed;
    }

    public void PlayerDead()
    {
        lives = lives - 1;

        live.text = "Lives: " + lives+"  ";
        PlayerPrefs.SetInt("Lives",lives);
        if(lives <= 0)
        {
            gameOver.GetComponent<GameWinScript>().GameOver();
            Destroy(this.gameObject);

        }
        else
        {
			Born.Play ();
			this.transform.position = new Vector3(-3.5f, 0.5f, 0f);
            //endP1.GetComponent<Collider2D>().isTrigger = true;
            //Application.LoadLevel(Application.loadedLevel);
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
