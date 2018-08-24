using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool GameOver; 
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		GameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame(){

		UiManager.instance.GameStart (); //can access any function due to instance.
		ScoreManager.instance.startScore ();
		GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner> ().StartSpawningPlatforms ();
	}

	public void gameOver(){
		UiManager.instance.GameOver ();
		ScoreManager.instance.StopScore ();
		GameOver = true;
	}
}
