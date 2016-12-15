using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tesla_GM : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject gamePanel;

	public Tesla_ScoreManager SM_Script;

	//Start ScoreManager Variables on GM
	public int score;
	public int round;
	public int targetScore;
	//END ScoreManager Variables on GM


	//Start GamePlay Variables
	public float windSpeed;
	public string windDirection;
	public int lives;
	public bool ballHit;

	public List<int> targetScoreList;
	//END GamePlay Variables

	// Use this for initialization
	void Start () {
		ballHit = false;
		ResetGame();

		SM_Script = GameObject.FindGameObjectWithTag ("SM").GetComponent<Tesla_ScoreManager>();

		targetScoreList = new List<int> ();
		targetScoreList.Add (25);
		targetScoreList.Add (50);
		targetScoreList.Add (75);
		targetScoreList.Add (90);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetGame(){
		score = 0;
		round = 0;
		lives = 5;

	}

	public void NewRound(){
		
	}

	public void UpdateScoreFromGM(){
		SM_Script.UpdateScore(score);
	}



	public void ReturnToGame(){
		menuPanel.SetActive (false);
		gamePanel.SetActive (true);
	}

	public void ReturnToMenu(){
		menuPanel.SetActive (true);
		gamePanel.SetActive (false);
	}





}
