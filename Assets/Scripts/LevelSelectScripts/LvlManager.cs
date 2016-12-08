using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour {


	public GameObject infoImage;
	public Image SR_image;
	public Sprite teslaInfo;
	public Sprite pharaohInfo;
	public Sprite arcInfo;
	public Sprite subdueInfo;
	public Sprite toucanInfo;
	public Sprite aussieblokesInfo;
	public Sprite covenantInfo;
	public Sprite timeageddonInfo;
	public string levelSelected;
	// Use this for initialization
	void Start () {

		SR_image = infoImage.GetComponent<Image> ();


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TestlaInfo(){

		infoImage.SetActive (true);
		SR_image.sprite = teslaInfo;
		levelSelected = "Tesla";
	}

	public void PharaohInfo(){
		
		infoImage.SetActive (true);
		SR_image.sprite = pharaohInfo;
	}

	public void ArcInfo(){
		
		infoImage.SetActive (true);
		SR_image.sprite = arcInfo;
	}
	public void SubdueInfo(){
		
		infoImage.SetActive (true);
		SR_image.sprite = subdueInfo;
	}
	public void ToucanInfo(){
		
		infoImage.SetActive (true);
		SR_image.sprite = toucanInfo;
	}
	public void AussieBlokesInfo(){
		
		infoImage.SetActive (true);
		SR_image.sprite = aussieblokesInfo;
	}
	public void CovenantInfo(){
		
		infoImage.SetActive (true);
		SR_image.sprite = covenantInfo;
	}
	public void TimeageddonInfo(){
		
		infoImage.SetActive (true);
		SR_image.sprite = timeageddonInfo;
	}
	public void LevelChange(){
		Debug.Log ("change level");
		if(levelSelected=="Tesla"){
			Application.LoadLevelAsync (2);

		}
	}
}
