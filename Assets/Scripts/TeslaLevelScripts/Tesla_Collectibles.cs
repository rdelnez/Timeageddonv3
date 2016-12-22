using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_Collectibles : MonoBehaviour {

	public Object particles;
	public Object pointsDisplay;
	public GameObject GM;
	public Tesla_GM GM_Script;
	// Use this for initialization
	void Start () {
		StartCoroutine (RotateCollectible());
		GM = GameObject.FindGameObjectWithTag ("GM");
		GM_Script = GM.GetComponent<Tesla_GM>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator RotateCollectible(){
		while(true){
			this.gameObject.transform.eulerAngles += new Vector3 (0, 5.0f, 0);
			//this.gameObject.transform.localRotation += new Vector3 (0,0.5f,0);
			yield return new WaitForSeconds (0.01f);
		}
	}

	void OnTriggerEnter(Collider coll){

		if(coll.CompareTag("ball")){
			Instantiate(particles,transform.localPosition, Quaternion.identity);
			Instantiate(pointsDisplay,transform.localPosition, Quaternion.identity);

			GM_Script.score += 12;
			//GM_Script.lastPointsAdded = points;
			//GM_Script.CheckLives();
			
			GM_Script.UpdateScoreFromGM ();

			Destroy(this.gameObject);
		}

	}

}
