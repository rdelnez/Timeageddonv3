using UnityEngine;
using System.Collections;

public class Tesla_Particle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyPart",1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void DestroyPart(){
		Destroy (this.gameObject);
	}

}
