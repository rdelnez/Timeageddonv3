using UnityEngine;
using System.Collections;

public class Tesla_GoalMidCollider : MonoBehaviour {

	public string objectTag;
	public int points;

	public Tesla_GM GM_Script;
	// Use this for initialization
	void Start () {
		objectTag = this.tag;

		GM_Script = GameObject.FindGameObjectWithTag ("GM").GetComponent<Tesla_GM>();

		if (objectTag == "Goal") {
			points = 6;
		} else if (objectTag == "Behind") {
			points = 1;
		} else {
			points = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//This is for the Goal
	void OnTriggerEnter(Collider coll){
		if(GM_Script.ballHit == false){
			GM_Script.ballHit = true;

			Debug.Log ("Hit the"+ objectTag);
			GM_Script.score += points;
			GM_Script.UpdateScoreFromGM ();
		}
	}


	//This if for the Post
	void OnCollisionEnter(Collision col){
		if (GM_Script.ballHit == false) {
			GM_Script.ballHit = true;

			Debug.Log ("Hit the" + objectTag);
			GM_Script.score += points;
			GM_Script.UpdateScoreFromGM ();
		}
	}
}
