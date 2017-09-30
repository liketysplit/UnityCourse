using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public void LoadLevel(string name){
	SceneManager.LoadScene(name);
    }

	public void QuitGame(){
	Application.Quit();
	}

    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

 //   public void BrickDestroyed() {
 //       print(Brick.brokenCount.ToString());
 //       if (Brick.brokenCount <= 0) {
            
 //           LoadNextLevel();
 //       }
 //   }
}

