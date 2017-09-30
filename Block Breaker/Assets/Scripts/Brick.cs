using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    private int count = 0;
    private LevelLoader levelLoader;
    public Sprite[] sprite;
    public static int brokenCount = 0;
    private bool isBreakable;
    public GameObject smoke;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable){
            brokenCount++;
            //print(brokenCount);
            //smoke.GetComponent<SpriteRenderer>().GetComponent<Color>().transform = 
        }
        levelLoader = GameObject.FindObjectOfType<LevelLoader>();
        count = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionExit2D(Collision2D collision){
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
            handleHits();

    }

    void handleHits() {

        int maxCount = sprite.Length + 1;
        count++;

        if (count >= maxCount)
        {
            brokenCount--;
            levelLoader.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            smokePuff.GetComponent<ParticleSystem>().startColor =(this.GetComponent<SpriteRenderer>().color); 
            Destroy(gameObject);
        }
        else
            LoadSprites();

    }


    private void LoadSprites(){
        int sIndex = count - 1;
        this.GetComponent<SpriteRenderer>().sprite = sprite[sIndex];
    }


}
