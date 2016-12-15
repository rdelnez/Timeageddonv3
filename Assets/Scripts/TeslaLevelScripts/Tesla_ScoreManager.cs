using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_ScoreManager : MonoBehaviour {

	public GameObject firstNumObject;
	public GameObject secondNumObject;
	public Image firstNumImage;
	public Image secondNumImage;

	public int firstNum;
	public int secondNum;

	public Sprite tempSprite;

	public string stringScore;
	// Use this for initialization
	void Start () {
		firstNumImage = firstNumObject.GetComponent<Image> ();
		secondNumImage = secondNumObject.GetComponent<Image> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateScore(int tempScore){
		//Debug.Log (tempScore);

		stringScore = tempScore.ToString ();
		//Debug.Log (stringScore.Length);

		if (stringScore.Length == 1) {
			//Debug.Log ("TeslaLevel/2D_Sprites/russ" + stringScore);

			tempSprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringScore);
			secondNumImage.sprite = tempSprite;
	
		} else {
			firstNumImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringScore[0]);
			secondNumImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + stringScore[1]);


		}
	}


}
