using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string name){
	Debug.Log ("Level load requested: " + name);
	SceneManager.LoadScene(name);
	}

	public void quitToStart(){
		SceneManager.LoadScene(Start);
	}

	public void quitGame(){
		Application.Quit();
	}

		
}
