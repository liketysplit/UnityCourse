using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizards : MonoBehaviour {
	public static int high = 1000, low = 1, mid = (high+low) / 2;
	public static int maxGuesses = 8;
	public Text text;

	public void Start () {
		startGame();	
	}
	public void startGame () {
		high = 1000;
		low = 1;
        mid = Random.Range(low, high + 1);
        text.text = mid.ToString();
        maxGuesses = 10;
	}
	public void Higher(){
		low = mid;
		nextGuess ();
	}

	public void Lower(){
		high = mid;
		nextGuess ();
	}

	void nextGuess () {
		if(maxGuesses == 0){
			//SceneManager.LoadScene("Win");
			Application.LoadLevel("Win");
		}
		else{
		mid = Random.Range(low,high+1) ;
		text.text = mid.ToString();
		maxGuesses--;
		}
	}

}
