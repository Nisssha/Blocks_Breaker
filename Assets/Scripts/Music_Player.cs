using UnityEngine;
using System.Collections;

public class Music_Player : MonoBehaviour {

	static Music_Player instance = null;
	
    //destroy this music player if another already exists, if not assign it as music player instance 
	void Awake()
    {
		if (instance != null)
        {
			Destroy(gameObject);
		}
		else
        {
		instance = this;
		GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
