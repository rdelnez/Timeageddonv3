using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_WindManager : MonoBehaviour {

	[SerializeField]
	private int randomNum;
	[SerializeField]
	private GameObject footyBall;
	[SerializeField]
	private Tesla_Ball footyBall_Script;
	[SerializeField]
	private ConstantForce footyBall_CF;

	public Image firstNumImage;
	public Image secondNumImage;
	public Image leftSign;
	public Image rightSign;
	public int firstNum;
	public int secondNum;
	public string stringWind;
	public Sprite tempSprite;

	public int windDirection;
	public int windRandomVariable;

	// Use this for initialization
	void Start () {
		windRandomVariable = 25;
		footyBall_Script = footyBall.GetComponent<Tesla_Ball> ();
		footyBall_CF = footyBall.GetComponent<ConstantForce> ();


		//Part of Gameplay

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void GetNewWindSpeed(int round){
		if (round == 1) {
			windRandomVariable=25;
		}
		else if(round == 2){
			windRandomVariable=50;
		}
		else if(round == 3){
			windRandomVariable=75;
		}
		else if(round == 4){
			windRandomVariable=100;
		}
			
		randomNum = (int)Random.Range (-windRandomVariable,windRandomVariable);
		footyBall_CF.force = new Vector3 (randomNum/2, 0.0f, 0.0f);


		windDirection = GetWindDirection(randomNum);
		UpdateWindSpeedDisplay (Mathf.Abs(randomNum));


	}



	public int GetWindDirection(int tempNum){
		if (tempNum > 0) {
			return 1;
		}
		else if(tempNum < 0){
			return -1;
		}

		return 0;
	}

	public void UpdateWindSpeedDisplay(int tempWind){
		stringWind = tempWind.ToString ();

		//Start Display for wind speed number
		if (stringWind.Length == 1) {
			//Debug.Log ("TeslaLevel/2D_Sprites/russ" + stringScore);
			
			tempSprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringWind);
			secondNumImage.sprite = tempSprite;
			
		} else {
			firstNumImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringWind[0]);
			secondNumImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringWind[1]);
			
			
		}
		//END Display for wind speed number


		//Start for Wind Direction Display
		if (windDirection > 0) {
			leftSign.gameObject.SetActive (false);
			rightSign.gameObject.SetActive (true);
			rightSign.GetComponent<WindArrow>().StartAnim();
		} else if (windDirection < 0) {
			leftSign.gameObject.SetActive (true);
			leftSign.GetComponent<WindArrow>().StartAnim();
			rightSign.gameObject.SetActive (false);

		} else {
			leftSign.gameObject.SetActive (false);
			rightSign.gameObject.SetActive (false);

		}
		//END for Wind Direction Display

	}


}
