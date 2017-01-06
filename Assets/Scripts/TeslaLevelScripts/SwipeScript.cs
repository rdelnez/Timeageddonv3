using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SwipeScript : MonoBehaviour {
	
	

	public GameObject textSendObject;
	public GameObject ballObject;
	public GameObject ground;
	public GameObject GM;
	public Tesla_GM GM_Script;
	public Tesla_BarManager BM_Script;


	public float startTime  = 0.0f;
	public Vector2 startPos = Vector2.zero;
	public Vector2 endPos = Vector2.zero;
	public bool isSwiping = false;
	public float swipeTime = 0.0f;
	public float swipeDist = 0.0f;
	private float minSwipeDist  = 20.0f;
	private float maxSwipeTime = 0.5f;
	private float minSwipeTime = 0.2f;
	public float differenceBetweenSwipeTimes;
	public float tempSpeedBarFloat;

	[SerializeField]
	private float xForceValue;
	[SerializeField]
	private float yForceValue;

	private float maxYForce = 700.0f;
	private float maxSwipeSpeed = 0.1f;

	public float tempBallSize;
	public Vector3 tempBallSizeVect3;
	public List<float> tempBallSizeList;

	
	
	// Update is called once per frame

	void Start(){
		GM_Script = GM.GetComponent<Tesla_GM> ();
		BM_Script = GameObject.FindGameObjectWithTag ("BM").GetComponent<Tesla_BarManager>();
		differenceBetweenSwipeTimes = maxSwipeTime - minSwipeTime;

		tempBallSizeList = new List<float> ();

		for(int x=0; x<55; x++){
			tempBallSizeList.Add (x*0.0185f);
		}



	}
	void Update () {
	

		
	}
	
	public void AddForceToBall(){
		if (isSwiping && swipeTime < maxSwipeTime && swipeDist > minSwipeDist){


			//END for Bar Display
			
			
			//Start Force Calculation
			xForceValue = endPos.x - startPos.x;
			yForceValue = endPos.y - startPos.y;
			
			textSendObject.GetComponent<Text>().text = "swipe successful";
			//Debug.Log ("adding force");
			
			ballObject.GetComponent<Rigidbody>().isKinematic = false;
			if(yForceValue > maxYForce){
				yForceValue = maxYForce;
			}

			if(swipeTime < minSwipeTime){
				swipeTime = minSwipeTime;
			}else if(swipeTime > maxSwipeTime){
				swipeTime = maxSwipeTime;

			}

			//Start for Bar Display
			StartCoroutine(StartBarDisplayComputation());
			//swipeTime/maxSwipeTime 

			//ballObject.GetComponent<Rigidbody>().AddForce(new Vector3(xForceValue,yForceValue*0.45f,yForceValue*1.3f)*(2/swipeTime));
			ballObject.GetComponent<Rigidbody>().AddForce(new Vector3(xForceValue,yForceValue*0.65f,yForceValue*1.8f)*(1.8f/swipeTime));
			ballObject.GetComponent<Rigidbody>().AddTorque(new Vector3(swipeDist*2.0f,0,0));
			StartCoroutine(ScaleBall());

			Invoke("ResetBall", 4.0f);
			
			
			//End Force Calculation
			
			
		}


	}

	IEnumerator StartBarDisplayComputation(){
		tempSpeedBarFloat = (differenceBetweenSwipeTimes/(swipeTime)-0.4f);
		//yield return new WaitForSeconds (0.5f);
		yield return null;
		BM_Script.UpdateBars(yForceValue/maxYForce, tempSpeedBarFloat);
	}

	public void SendMessage(){


	}

	public void ResetBall(){
		if(GM_Script.lastPointsAdded==0){
			GM_Script.UpdateReferee ();
		}
		ballObject.GetComponent<Rigidbody>().isKinematic = true;
		ballObject.transform.localPosition = new Vector3 (0, -3.44f, -54.4f);
		ballObject.transform.localEulerAngles = new Vector3 (90,270,0);
		ballObject.transform.localScale = new Vector3 (1, 1, 1);
		GM_Script.ballHit = false;
		BM_Script.ResetBars ();
		GM_Script.ChangeWind ();
		GM_Script.CheckGameState ();
		GM_Script.CheckLives();
	}

	IEnumerator ScaleBall(){
		/*--
		for(int x=1; x<100; x++){
			//tempBallSize = Mathf.Abs (ballObject.transform.localPosition.z)/54.4f;


			Debug.Log (tempBallSize);
			ballObject.transform.localScale = new Vector3(tempBallSize, tempBallSize, tempBallSize);
		
			yield return new WaitForSeconds(0.02f);
		}
		--*/

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


	}


	
}