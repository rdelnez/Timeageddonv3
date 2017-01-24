using UnityEngine;
using System.Collections;

public class Iphone : MonoBehaviour {

	public Object particle;
	public GameObject particlePrefabs;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += new Vector3 (0.05f, 0, 0); 
		transform.localEulerAngles += new Vector3 (0, 10.05f, 0);
		particlePrefabs = Instantiate (particle, this.transform.localPosition, Quaternion.identity) as GameObject;
	}


}
