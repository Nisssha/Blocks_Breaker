using UnityEngine;
using System.Collections;

public class LevelMenager : MonoBehaviour {


	public void LoadLevel (string name){
		Application.LoadLevel (name);
		}
	
	public void QuitFunction () {
		Application.Quit ();
	}
	
	public void LoadNextLevel () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
    //Load next level in build if all of the bricks were destroyed
	public void BrickDestroyed () {
		if (Block_1hit.breakableCount <= 0) {LoadNextLevel();}
	}
}
