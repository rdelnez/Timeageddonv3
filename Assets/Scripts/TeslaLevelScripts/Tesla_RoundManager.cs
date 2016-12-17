using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_RoundManager : MonoBehaviour {


	public Image firstBarImage;
	public Image secondBarImage;
	public Image thirdBarImage;
	public Image fourthBarImage;
	
	public Sprite tempSprite;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateRoundBarDisplay(int round){
		if(round==1){
			firstBarImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/HUDroundlighton");
		}
		else if(round==2){
			secondBarImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/HUDroundlighton");
		}
		else if(round==3){
			thirdBarImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/HUDroundlighton");
		}
		else if(round==4){
			fourthBarImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/HUDroundlighton");
		}
	}
}
