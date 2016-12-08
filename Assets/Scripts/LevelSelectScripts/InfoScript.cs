using UnityEngine;
using System.Collections;

public class InfoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)){
			Debug.Log("isclicked");
			
		}
	}
}
