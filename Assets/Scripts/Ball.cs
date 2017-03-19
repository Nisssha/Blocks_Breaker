using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	public bool gameStarted;
	private Vector3 paddleToBallVector;
	public Vector2 tweak; 
	
	void Start ()
    {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		gameStarted = false;
	}
	
    //handle change of direction of the ball if it hits something
	void OnCollisionEnter2D (Collision2D col)
    {
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range (0f, 0.3f));
		GetComponent<Rigidbody2D>().velocity += tweak;
		if(gameStarted){
		GetComponent<AudioSource>().Play ();}
	}
	
    //handle moving the ball after game has started
	void Update ()
    {
		if (gameStarted == false)
        {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0))
            {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
				gameStarted = true;
			}
		}	
	}
	
    //if game was not started(ball has not been launched) maintain position of ball on tha paddle
    //if left mouse button is pressed launch the ball and set the game started to true
	void MoveWithMouse ()
    {
		if (gameStarted == false)
        {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0))
            {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
				gameStarted = true;
			}
		}
	}
}

