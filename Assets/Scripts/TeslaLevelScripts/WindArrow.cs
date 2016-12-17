using UnityEngine;
using System.Collections;

public class WindArrow : MonoBehaviour {

	[SerializeField]
	private Vector3 originalArrowSize;
	[SerializeField]
	private Vector3 tempArrowSize;
	[SerializeField]
	private float subtractor;
	// Use this for initialization
	void Start () {
		originalArrowSize = new Vector3(0.06f,0.6f,1.0f);
		subtractor = 0.003f;
		StartCoroutine (AnimateArrow ());
	
	}

	public void StartAnim(){
		StartCoroutine (AnimateArrow ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator AnimateArrow(){
		/*--

		
		for(int x=65; x>0; x--){
			tempBallSize = Mathf.Abs (ballObject.transform.localPosition.z);
			Debug.Log (tempBallSize);
			if(tempBallSize<6.0f){
				tempBallSize = 6.0f;
				break;
			}
			ballObject.transform.localScale = new Vector3(tempBallSizeList[(int)tempBallSize], tempBallSizeList[(int)tempBallSize], tempBallSizeList[(int)tempBallSize]);
			ground.transform.localScale = new Vector3(tempBallSizeList[(int)tempBallSize], tempBallSizeList[(int)tempBallSize], tempBallSizeList[(int)tempBallSize]);
			
			yield return new WaitForSeconds(0.02f);
			
			
		}
		--*/

		while(true){
			tempArrowSize = originalArrowSize;
			for(int x=0; x<5; x++){
				tempArrowSize = tempArrowSize+new Vector3(subtractor, subtractor*5,1);
				transform.localScale = tempArrowSize;
				yield return new WaitForSeconds(0.15f);
			}

		}
		
		
	}
}
