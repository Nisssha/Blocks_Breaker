using UnityEngine;
using System.Collections;

public class Outline : MonoBehaviour {

	private LevelMenager levelMenager;

    //loosing game if the ball enters bottom collider

	void OnTriggerEnter2D (Collider2D collider)
    {
		levelMenager = GameObject.FindObjectOfType<LevelMenager>();
		Block_1hit.breakableCount = 0;
		levelMenager.LoadLevel ("Lose");
	}
	
}
