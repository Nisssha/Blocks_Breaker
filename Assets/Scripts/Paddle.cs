using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	
	void Start()
    {
	ball = GameObject.FindObjectOfType <Ball>();
	}

	void Update ()
    {
		if (!autoPlay)
        {
			MoveWithMouse();
		}
        else
        {
			AutoPlay();
		}
	}
	
    //moving paddle according to mouse position
	void MoveWithMouse ()
    {
		float mousePosInBlocks = Input.mousePosition.x /Screen.width*16;
		this.transform.position = new Vector3(Mathf.Clamp (mousePosInBlocks, 1f, 15f), this.transform.position.y , this.transform.position.z);
	}
	
    //autoplay mode for testing - moving paddle according to ball position
	void AutoPlay()
    {
		Vector3 ballPosition = ball.transform.position;
		this.transform.position = new Vector3(Mathf.Clamp (ballPosition.x, 1f, 15f), this.transform.position.y , this.transform.position.z);
	}
}
