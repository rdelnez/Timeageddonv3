﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Tesla_GM : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject gamePanel;

	public Tesla_ScoreManager SM_Script;
	public Tesla_WindManager WM_Script;
	public Tesla_RoundManager RM_Script;
	public Tesla_LivesManager LM_Script;

	//Start ScoreManager Variables on GM
	public int score;
	public int lastPointsAdded;
	public int round;
	public int targetScore;
	public Image targetNum1;
	public Image targetNum2;
	public int firstNum;
	public int secondNum;
	public Sprite tempSprite;
	public string stringTargetScore;
	//END ScoreManager Variables on GM


	//Start GamePlay Variables
	public float windSpeed;
	public string windDirection;
	public int lives;
	public bool ballHit;
	public bool isWindChange;

	public List<int> targetScoreList;
	//END GamePlay Variables

	// Use this for initialization
	void Start () {
		SM_Script = GameObject.FindGameObjectWithTag ("SM").GetComponent<Tesla_ScoreManager>();
		WM_Script = GameObject.FindGameObjectWithTag ("WM").GetComponent<Tesla_WindManager>();
		RM_Script = GameObject.FindGameObjectWithTag ("RM").GetComponent<Tesla_RoundManager>();
		LM_Script = GameObject.FindGameObjectWithTag ("LM").GetComponent<Tesla_LivesManager>();


		targetScoreList = new List<int> ();
		targetScoreList.Add (25);
		targetScoreList.Add (50);
		targetScoreList.Add (75);
		targetScoreList.Add (90);

		ResetGame();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetGame(){

		ballHit = false;
		isWindChange = false;

		score = 0;
		round = 1;
		lives = 5;

		WM_Script.GetNewWindSpeed (round);
		RM_Script.UpdateRoundBarDisplay (round);
		LM_Script.UpdateLivesDisplay (lives);

		targetScore = targetScoreList [round - 1];
		UpdateTargetScoreDisplay (targetScore);

	}

	public void CheckGameState(){
		if(score>=targetScore){

			score = 0;
			lives = 5;

			round++;
			targetScore = targetScoreList [round - 1];

			UpdateTargetScoreDisplay (targetScore);
			RM_Script.UpdateRoundBarDisplay (round);
			SM_Script.UpdateScore(score);

		}


	}

	public void CheckLives(){
		if (lastPointsAdded == 0) {
			lives -= 1;
			LM_Script.UpdateLivesDisplay (lives);
		} else {
			lastPointsAdded = 0;
		}
	}

	public void UpdateTargetScoreDisplay(int tempTargetScore){
		//Debug.Log (tempScore);


		stringTargetScore = tempTargetScore.ToString ();
		//Debug.Log (stringScore.Length);
		
	
		targetNum1.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringTargetScore[1]);
		targetNum2.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringTargetScore[0]);
			
			
	
	}

	public void NewRound(){
		
	}

	public void UpdateScoreFromGM(){
		SM_Script.UpdateScore(score);
	}

	public void ChangeWind(){
		if(isWindChange==true){
			WM_Script.GetNewWindSpeed(round);
			isWindChange=false;
		}
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
