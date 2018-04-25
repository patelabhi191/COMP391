using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinScript : MonoBehaviour {

    public Text text;
    public GameObject panel;
	// Use this for initialization
	void Start () {
		    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Game Over;
            text.text = "You Win !";
            panel.GetComponent<Animator>().enabled = true;
        }
    }
    public void GameOver()
    {
        text.text = "Game Over !";
        panel.GetComponent<Animator>().enabled = true;
    }
}
