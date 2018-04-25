using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    public GameObject[] gates;
	public AudioSource butt;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i=gates.Length-1; i>=0; i--)
        {
            Destroy(gates[i].gameObject);
			butt.Play ();
	     }
    }
}
