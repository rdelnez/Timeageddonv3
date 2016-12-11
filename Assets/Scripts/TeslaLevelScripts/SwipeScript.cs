using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeScript : MonoBehaviour {
	
	

	public GameObject textSendObject;
	public GameObject ballObject;


	private float startTime  = 0.0f;
	private Vector2 startPos = Vector2.zero;
	private bool isSwiping = false;
	private float minSwipeDist  = 20.0f;
	private float maxSwipeTime = 1.0f;
	private float xForceValue;
	private float yForceValue;
	
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0){
			
			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began :
					//start of touch
					isSwiping = true;
					startTime = Time.time;
					startPos = touch.position;
					break;
					
				case TouchPhase.Canceled :
					//start of cancel swipe
					isSwiping = false;
					break;
					
				case TouchPhase.Ended :
					
					float swipeTime = Time.time - startTime;
					float swipeDist = (touch.position - startPos).magnitude;
					
					if (isSwiping && swipeTime < maxSwipeTime && swipeDist > minSwipeDist){
	

						//Start Force Calculation
						xForceValue = startPos.x - touch.position.x;
						yForceValue = startPos.y - touch.position.y;

						textSendObject.GetComponent<Text>().text = "swipe successful.. adding force";
						Debug.Log ("adding force");
						
						ballObject.GetComponent<Rigidbody>().isKinematic = false;
						ballObject.GetComponent<Rigidbody>().AddForce(new Vector3(-xForceValue,-yForceValue,yForceValue));
						ballObject.GetComponent<Rigidbody>().AddTorque(new Vector3(swipeDist*2.0f,0,0));
						StartCoroutine(ScaleBall());



						//End Force Calculation

	
					}
					
					break;
				}
			}

			Invoke("ResetBall", 5.0f);
		}
		
	}

	public void SendMessage(){


	}

	public void ResetBall(){

		ballObject.GetComponent<Rigidbody>().isKinematic = true;
		ballObject.transform.localPosition = new Vector3 (0, 1.19f, -2.74f);
		ballObject.transform.localEulerAngles = new Vector3 (90,60,0);
		ballObject.transform.localScale = new Vector3 (1, 1, 1);
	}

	IEnumerator ScaleBall(){
		for(int x=0; x<40; x++){
			ballObject.transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
		
			yield return new WaitForSeconds(0.04f);
		}

	}
}