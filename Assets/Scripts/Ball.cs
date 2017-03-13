using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	//private float thrust;
	public bool gameStarted;
	private Vector3 paddleToBallVector;
	public Vector2 tweak; 
	
		// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//thrust = 900f;
		gameStarted = false;
	}
	
	void OnCollisionEnter2D (Collision2D col) {
	
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range (0f, 0.3f));
		GetComponent<Rigidbody2D>().velocity += tweak;
		//print ("tweak: " +tweak +", velocity: " +rigidbody2D.velocity);
		if(gameStarted){
		GetComponent<AudioSource>().Play ();}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted == false) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0)){
				//this.rigidbody2D.AddForce (transform.up *thrust);
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
				gameStarted = true;
			}
		}
		
	}
	
	void MoveWithMouse () {
	
		if (gameStarted == false) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0)){
				//this.rigidbody2D.AddForce (transform.up *thrust);
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
				gameStarted = true;
			}
		}
	}
}

