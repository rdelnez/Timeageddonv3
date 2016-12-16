using UnityEngine;
using System.Collections;

public class FootyGround_Script : MonoBehaviour {

	public GameObject footyBall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.localPosition = new Vector3 (footyBall.transform.localPosition.x, -45, footyBall.transform.localPosition.z);
		transform.localPosition = new Vector3 (footyBall.transform.localPosition.x, footyBall.GetComponent<Tesla_Ball>().rayHit.point.y+0.1f, footyBall.transform.localPosition.z);
	
	}
}
