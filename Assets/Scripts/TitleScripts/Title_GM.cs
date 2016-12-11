using UnityEngine;
using System.Collections;

public class Title_GM : MonoBehaviour {

	public GameObject canvas;
	public GameObject bgImage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartStoryMode(){
		//Application.LoadLevel (1);
		//canvas.SetActive (false);

		Application.LoadLevelAsync (1);
		bgImage.SetActive (false);
		canvas.SetActive (false);
	


	}
}
