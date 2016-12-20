using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_BarManager : MonoBehaviour {


	public Scrollbar strengScrollBar;
	public Scrollbar speedScrollBar;
	public bool isBarReset;
	// Use this for initialization
	void Start () {
		isBarReset = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateBars(float tempStr, float tempSpeed){
	//	strengScrollBar.size = tempStr;
	//	speedScrollBar.size = tempSpeed;

		isBarReset = false;
		StartCoroutine (AnimateStrBar(tempStr));
		StartCoroutine (AnimateSpeedBar(tempSpeed));

	}

	IEnumerator AnimateStrBar(float str){
		yield return null;
		strengScrollBar.size = 0;
		while(strengScrollBar.size < str && isBarReset==false){
			strengScrollBar.size+=0.1f;
			yield return new WaitForSeconds(0.03f);
		}

	}

	IEnumerator AnimateSpeedBar(float speed){
		yield return null;
		speedScrollBar.size = 0;
		while(speedScrollBar.size < speed  && isBarReset==false){
			speedScrollBar.size+=0.1f;
			yield return new WaitForSeconds(0.03f);
		}

	}

	public void ResetBars(){
		isBarReset = true;
		strengScrollBar.size = -0.5f;
		speedScrollBar.size = -0.5f;
		StopCoroutine (AnimateSpeedBar(0.0f));
		StopCoroutine (AnimateStrBar(0.0f));
	}
}
