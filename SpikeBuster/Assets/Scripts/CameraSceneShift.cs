using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSceneShift : MonoBehaviour {
    public Camera mainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mainCamera.transform.position += new Vector3(14f, -1f, 0f);
        collision.transform.position += new Vector3(1f,0f,0f);
        Collider2D coli = this.GetComponent<Collider2D>();
        coli.isTrigger = false;
    }
}
