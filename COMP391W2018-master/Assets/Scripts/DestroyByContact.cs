using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosionAsteroid;
	public GameObject explosionSpaceShip;
	public int scoreValue=10;
	private GameController gamecontrollerscript;

	// Use this for initialization
	void Start () {
		GameObject gamecontrollerobject = GameObject.FindWithTag ("GameController");
		if (gamecontrollerobject != null) 
		{
			gamecontrollerscript = gamecontrollerobject.GetComponent<GameController> ();
		}
		if (gamecontrollerobject == null) 
		{
			Debug.Log ("No script attached");
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Player") 
		{
			Instantiate (explosionSpaceShip, other.transform.position, other.transform.rotation);
			gamecontrollerscript.GameOver ();
			gamecontrollerscript.end.text="Game Over";
		}

        if(other.tag == "Boundary")
        {
            return;
            // Debug.Log("DestroyByContact");
        }

        Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);
		gamecontrollerscript.AddScore (scoreValue);
        Destroy(other.gameObject); // Destroy the other thing (laser)
        Destroy(this.gameObject); // Destroying this thing (the asteroid)
    }
}
