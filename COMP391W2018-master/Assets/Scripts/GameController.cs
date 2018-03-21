using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject Hazard;
	public Vector2 spawnValue;
	public int count;
	public float spawnWait;
	public float startWait;
	public float wavewait;
	private bool gameOver;
	private bool restart;
	private int score;

	public Text Score;
	public Text restat;
	public Text end;

	// Use this for initialization
	void Start () 
	{
		score = 0;
		StartCoroutine (SpawnWaves());
		restat.text = " ";
		end.text = " ";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				SceneManager.LoadScene ("Spaceshooter");
			//	SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex); another way to load scene
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) 
		{
			for(int i=0;i<count;i++)
			{
				Vector2 spawnPosition = new Vector2(spawnValue.x,Random.Range(-spawnValue.y,spawnValue.y));

				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (Hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (wavewait);
			if (gameOver) 
			{
				break;
			}
		}if (gameOver) 
		{
			restat.text="Press R to Restart";

		}
	}
	void UpdateScore()
	{
		Score.text = "Score- " + score;
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		Debug.Log ("Score is " + score);
		UpdateScore ();
	}
	public void GameOver()
	{
		Debug.Log ("Game Ends");
		gameOver=true;
	}
}
