using UnityEngine;
using System.Collections;

public class Title_GM : MonoBehaviour {

	public GameObject canvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartStoryMode(){
		//Application.LoadLevel (1);
		canvas.SetActive (false);
		Application.LoadLevelAsync (1);
	


	}
}
