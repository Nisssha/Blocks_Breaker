using UnityEngine;
using System.Collections;

public class Block_1hit : MonoBehaviour {

	public AudioClip bounce;
	public static int breakableCount = 0;
	private int timesHit;
	public GameObject[] Brick;
	private LevelMenager levelMenager;
	public Sprite[] hitSprites;
	private bool isBreakable;
	public GameObject smoke;
	
	void Start() {
	
		isBreakable = (this.tag == "Brick");
		//Keep track of number of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		levelMenager = GameObject.FindObjectOfType<LevelMenager>();
		timesHit = 0;
	}
	
    //check if hit object is breakable, play audio effect of hit
	void OnCollisionEnter2D (Collision2D col) {
		
		if (isBreakable) {HandleHits();}
		AudioSource.PlayClipAtPoint(bounce, transform.position);
	}
	
    //add hit, check if brick should be destoyed according to number of times it has been hit, if yes: destroy it, decrease
    //amount of breakable objects in scene, create particle system for smoke
    //if it should not be destroyed change sprite
	void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length +1;
		if (timesHit >= maxHits) {
			Destroy(gameObject);
			breakableCount--;
			GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			levelMenager.BrickDestroyed();}
		else {LoadSprites();}		
	}
	
    //changing sprite to next sprite in array
	void LoadSprites () {
		int SpriteIndex = timesHit -1;
		if (hitSprites[SpriteIndex]) {
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
		}else {Debug.LogError ("Sprite not found");}
	}
}
