using UnityEngine;
using System.Collections;

public class Tesla_Ball : MonoBehaviour {
	
	public GameObject swipeScriptObject;
	public SwipeScript swipeScript;
	// Use this for initialization
	void Start () {
		
		swipeScript = swipeScriptObject.GetComponent<SwipeScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnMouseOver(){
		
	//	Debug.Log ("Mouse is over the ball");
	}
	
	void OnMouseDown(){


		swipeScript.isSwiping = true;
		swipeScript.startTime = Time.time;
		swipeScript.startPos = Input.mousePosition;

	}
	
	void OnMouseUp(){
		swipeScript.endPos = Input.mousePosition;
	//	Debug.Log ("Mouse is Up or Been depressed");

		swipeScript.swipeTime = Time.time - swipeScript.startTime;
		swipeScript.swipeDist = (swipeScript.endPos - swipeScript.startPos).magnitude;

		swipeScript.AddForceToBall ();



	}
	
	void OnMouseExit(){
		
	//	Debug.Log ("Mouse is out");
		
	}
}
