using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Use this for initialization
	void Start () 
	{
		score = 0;
		StartCoroutine (SpawnWaves());	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		Debug.Log ("Score is " + score);
	}
	public void GameOver()
	{
		Debug.Log ("Game Ends");
		gameOver=true;
	}
}
