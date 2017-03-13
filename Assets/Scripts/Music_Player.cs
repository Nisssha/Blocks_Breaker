using UnityEngine;
using System.Collections;

public class Music_Player : MonoBehaviour {

	static Music_Player instance = null;
	 
	void Awake() {
		
		if (instance != null) {
			Destroy(gameObject);
			print ("hulk smash");
		}
		else{
		instance = this;
		GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
