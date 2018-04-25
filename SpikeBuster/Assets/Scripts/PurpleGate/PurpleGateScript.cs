using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleGateScript : MonoBehaviour {

    public GameObject button1;
    public GameObject button2;

    SingleButton b1,b2;
    // Use this for initialization
    void Start () {
        b1 = button1.GetComponent<SingleButton>();
        b2 = button2.GetComponent<SingleButton>();
    }
	
	// Update is called once per frame
	void Update () {
		if(b1.isPressed() && b2.isPressed())
        {
            Destroy(this.gameObject);
        }
	}
}
