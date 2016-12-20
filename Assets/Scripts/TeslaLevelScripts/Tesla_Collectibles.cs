using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tesla_Collectibles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (RotateCollectible());
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

}
