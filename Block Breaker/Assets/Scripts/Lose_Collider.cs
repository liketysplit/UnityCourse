using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_Collider : MonoBehaviour {

    public LevelLoader levelLoader;

	void OnTriggerEnter2D (Collider2D trigger) {
        levelLoader = GameObject.FindObjectOfType<LevelLoader>();
        levelLoader.LoadLevel("Lose");
        Brick.brokenCount = 0;
    }

   
    void OnCollisionEnter2D(Collision2D collision){
        print("Collision");
        //levelLoader.LoadLevel("Lose");
    }

}
