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
	//public GameObject puff;
	//public GameObject brick;
	
	void Start() {
	
		isBreakable = (this.tag == "Brick");
		//Keep track of number of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		levelMenager = GameObject.FindObjectOfType<LevelMenager>();
		timesHit = 0;
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		
		if (isBreakable) {HandleHits();}
		AudioSource.PlayClipAtPoint(bounce, transform.position);
	}
	
	void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length +1;
		if (timesHit >= maxHits) {
			Destroy(gameObject);
			breakableCount--;
			//smoke.renderer.material.SetColor("_Color", this.renderer.material.color);
			GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			//puff = smoke;
			levelMenager.BrickDestroyed();}
		else {LoadSprites();}		
	}
	
	void LoadSprites () {
		int SpriteIndex = timesHit -1;
		if (hitSprites[SpriteIndex]) {
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
		}else {Debug.LogError ("brak spritea");}
	}
}
