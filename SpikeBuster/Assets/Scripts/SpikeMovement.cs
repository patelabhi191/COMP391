using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour {

    public GameObject nextSpike;
    Animator anim;
    Collider2D coli;
    Animator selfAnim;
    Collider2D selfColi;
	public AudioSource Strike;
	// Use this for initialization
	void Start () {
        anim = nextSpike.GetComponent<Animator>();
        selfAnim = this.GetComponent<Animator>();

        coli = nextSpike.GetComponent<Collider2D>();
        selfColi = this.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void stopThis()
    {
        anim.enabled = !(anim.enabled);
        coli.enabled = !(coli.enabled);
        selfAnim.enabled = !(selfAnim.enabled);
        selfColi.enabled = !(selfColi.enabled);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);

            //life system
            collision.GetComponent<PlayerMovement>().PlayerDead();

        }
    }
}
