using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tesla_FactManager : MonoBehaviour {

	public List<Sprite> factSprites;
	// Use this for initialization
	void Start () {

		factSprites = new List<Sprite> ();
		for (int x = 1; x<19; x++) {
			factSprites.Add (Resources.Load<Sprite>("TeslaLevel/2D_Sprites/Facts/TeslaFact"+x));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
