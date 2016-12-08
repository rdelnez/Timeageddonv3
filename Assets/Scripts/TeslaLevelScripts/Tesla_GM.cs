using UnityEngine;
using System.Collections;

public class Tesla_GM : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject gamePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
