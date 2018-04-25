using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButton : MonoBehaviour {
    bool pressed;
	public AudioSource sound;
	// Use this for initialization
	void Start () {
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pressed = true;
		sound.Play ();
    }
    public bool isPressed()
    {
        return pressed;
    }
}
