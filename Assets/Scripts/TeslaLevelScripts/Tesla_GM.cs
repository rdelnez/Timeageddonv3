using UnityEngine;
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
	public Tesla_BarManager BM_Script;

	
	public Sprite point6Image;
	public Sprite point1Image;
	public Sprite point0Image;
	public GameObject refereeObject;
	public Tesla_Referee refereeObjectScript;

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

	//Start Collectibles
	public Object collectiblePrefab;
	public GameObject collectible;
	public List<Vector3> listCollectiblePos;
	//END Collectibles


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
		BM_Script = GameObject.FindGameObjectWithTag ("BM").GetComponent<Tesla_BarManager>();

		refereeObjectScript = refereeObject.GetComponent<Tesla_Referee> ();
		point6Image = Resources.Load<Sprite>("TeslaLevel/2D_Sprites/Referee/tophatScore6");
		point1Image = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/Referee/tophatScore1");
		point0Image = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/Referee/tophatScoreWide");


		targetScoreList = new List<int> ();
		targetScoreList.Add (25);
		targetScoreList.Add (50);
		targetScoreList.Add (75);
		targetScoreList.Add (90);

		listCollectiblePos = new List<Vector3> ();
		listCollectiblePos.Add (new Vector3(1.31f, 2.2f, -7.88f));
		listCollectiblePos.Add (new Vector3(-1.43f, 2.2f, -7.88f));
		listCollectiblePos.Add (new Vector3(-3.97f, 0.29f, -7.88f));
		listCollectiblePos.Add (new Vector3(3.97f, 0.29f, -7.88f));


		ResetGame();
		RespawnCollectibles();

	
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
			if(!collectible){
			RespawnCollectibles();
			}
			RM_Script.UpdateRoundBarDisplay (round);
			SM_Script.UpdateScore(score);

		}


	}

	public void RespawnCollectibles(){

		collectible = Instantiate (collectiblePrefab, listCollectiblePos [Random.Range (0,listCollectiblePos.Count)], Quaternion.identity) as GameObject;
		collectible.transform.eulerAngles = new Vector3 (-90, 180, 0);
		//(int)Random.Range (0, listCollectiblePos.Count)
	}

	public void ChangeReferee(){
		if (lastPointsAdded == 6) {
			refereeObjectScript.GetComponent<Image> ().sprite = point6Image;
		} else if (lastPointsAdded == 1) {
			refereeObjectScript.GetComponent<Image> ().sprite = point1Image;
		} else {
			refereeObjectScript.GetComponent<Image> ().sprite = point0Image;
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

			UpdateReferee ();

	}

	public void UpdateReferee(){
		refereeObject.SetActive (true);
		ChangeReferee ();

		Invoke ("RemoveRefereeDisplay",2.0f);
	}

	public void RemoveRefereeDisplay(){
		refereeObject.SetActive (false);
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
