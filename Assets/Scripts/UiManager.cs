using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour {

	public static UiManager instance;
	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public Text score;
	public Text highScore1;
	public Text highScore2;
	public GameObject taptext;

	void Awake (){
		if (instance == null) {
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		highScore2.text = "High Score: " + PlayerPrefs.GetInt ("highScore");
		highScore1.text = PlayerPrefs.GetInt("highScore").ToString();

	}

	public void GameStart(){

		taptext.SetActive (false);
		zigzagPanel.GetComponent<Animator>().Play("PanelUP");
	}

	public void GameOver(){
		score.text = PlayerPrefs.GetInt ("score").ToString();
		highScore2.text = PlayerPrefs.GetInt ("highScore").ToString();
		gameOverPanel.SetActive (true);
	}

	public void Reset(){
        SceneManager.LoadScene(0);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
