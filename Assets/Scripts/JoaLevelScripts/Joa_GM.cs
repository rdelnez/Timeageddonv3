using UnityEngine;
using System.Collections;

public class Joa_GM : MonoBehaviour {

	public Vector3 origPos = new Vector3 (1, 1, -11.73f);
	public Object football;
	public GameObject footballInstantiated;


	// Use this for initialization
	void Start () {

		football = Resources.Load("JoaLevel/Prefabs/football");

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire1")) {

			footballInstantiated = Instantiate(football, origPos, Quaternion.identity) as GameObject;

		}

	}
}
