using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_LivesManager : MonoBehaviour {

	public Image livesNumImage;

	
	public int livesNum;
	public Sprite tempSprite;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateLivesDisplay(int life){
		livesNumImage.sprite = Resources.Load<Sprite> ("TeslaLevel/2D_Sprites/russ" + life);
	}
}
