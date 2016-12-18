using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_BarManager : MonoBehaviour {


	public Scrollbar strengScrollBar;
	public Scrollbar speedScrollBar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateBars(float tempStr, float tempSpeed){
	//	strengScrollBar.size = tempStr;
	//	speedScrollBar.size = tempSpeed;

		StartCoroutine (AnimateStrBar(tempStr));
		StartCoroutine (AnimateSpeedBar(tempSpeed));

	}

	IEnumerator AnimateStrBar(float str){
		yield return null;
		strengScrollBar.size = 0;
		while(strengScrollBar.size < str){
			strengScrollBar.size+=0.1f;
			yield return new WaitForSeconds(0.03f);
		}
		StopCoroutine (AnimateStrBar(0.0f));
	}

	IEnumerator AnimateSpeedBar(float speed){
		yield return null;
		speedScrollBar.size = 0;
		while(speedScrollBar.size < speed){
			speedScrollBar.size+=0.1f;
			yield return new WaitForSeconds(0.03f);
		}
		StopCoroutine (AnimateSpeedBar(0.0f));
	}

	public void ResetBars(){
		strengScrollBar.size = -0.5f;
		speedScrollBar.size = -0.5f;

	}
}
