using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	
	void Start(){
	ball = GameObject.FindObjectOfType <Ball>();
	}
	// Update is called once per frame
	void Update () {
	
		if (!autoPlay){
			MoveWithMouse();
		}else{
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		float mousePosInBlocks = Input.mousePosition.x /Screen.width*16;
		//print (mousePosInBlocks);
		
		//if (1 < mousePosInBlocks && mousePosInBlocks < 15) {
		this.transform.position = new Vector3(Mathf.Clamp (mousePosInBlocks, 1f, 15f), this.transform.position.y , this.transform.position.z);
		//}
	}
	
	void AutoPlay() {
	 
		Vector3 ballPosition = ball.transform.position;
		print (ballPosition);
		this.transform.position = new Vector3(Mathf.Clamp (ballPosition.x, 1f, 15f), this.transform.position.y , this.transform.position.z);
	}
}
