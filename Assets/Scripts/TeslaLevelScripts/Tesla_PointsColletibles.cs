using UnityEngine;
using System.Collections;

public class Tesla_PointsColletibles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyPoints",2.0f);
		StartCoroutine (AnimatePoints ());
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	IEnumerator AnimatePoints(){
		while(true){
			transform.localPosition += new Vector3 (0,0.1f,0);
			yield return new WaitForSeconds(0.02f);
		}
	}
	
	private void DestroyPoints(){
		Destroy (this.gameObject);
	}
}
