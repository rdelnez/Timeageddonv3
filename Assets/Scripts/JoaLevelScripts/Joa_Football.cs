using UnityEngine;
using System.Collections;

public class Joa_Football : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		transform.position = new Vector3 (0, 0, 40);

	}
}
