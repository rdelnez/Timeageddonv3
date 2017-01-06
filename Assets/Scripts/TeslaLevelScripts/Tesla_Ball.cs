using UnityEngine;
using System.Collections;

public class Tesla_Ball : MonoBehaviour {
	
	public GameObject swipeScriptObject;
	public SwipeScript swipeScript;
	public GameObject ground;
	public RaycastHit rayHit;
	public Tesla_GM GM_Script;

	public LineRenderer line;
	// Use this for initialization
	void Start () {
		
		swipeScript = swipeScriptObject.GetComponent<SwipeScript> ();
		GM_Script = GameObject.FindGameObjectWithTag ("GM").GetComponent<Tesla_GM>();
		line = this.GetComponent<LineRenderer> ();


		
	}
	
	// Update is called once per frame
	void Update () {
		SetUpRaycastHit ();
		SetupLine ();
		//DrawLine (); not beign used
		
		
		
	}
	
	void OnMouseOver(){
		
	//	Debug.Log ("Mouse is over the ball");
	}
	
	void OnMouseDown(){

		GM_Script.lastPointsAdded = 0;

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

	void SetUpRaycastHit(){
		if (Physics.Raycast (transform.localPosition, -Vector3.up, out rayHit, 100.0f)) {

		}

	}

	void SetupLine()
	{
		line.sortingLayerName = "OnTop";
		line.sortingOrder = 5;
		line.SetVertexCount(2);
		line.SetPosition(0, transform.localPosition);
		line.SetPosition(1, ground.transform.localPosition);
		//line.SetPosition(2, transform.localPosition);
		line.SetWidth(0.01f, 0.01f);
		line.useWorldSpace = true;

	}

	void DrawLine()
	{
		line.SetPosition(0, transform.localPosition);
		//storedLinePoints.Add(newPoint); // add the new point to our saved list of line points
		//line.SetVertexCount(storedLinePoints.Count); // set the line’s vertex count to how many points we now have, which will be 1 more than it is currently
		line.SetPosition(0, ground.transform.localPosition); // add newPoint as the last point on the line (count -1 because the SetPosition is 0-based and Count is 1-based)    
	}
}
