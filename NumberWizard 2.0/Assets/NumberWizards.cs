using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizards : MonoBehaviour {
	public static int high = 1000, low = 1, mid = (high+low) / 2;
	public static int maxGuesses = 10;
	public Text text;

	public void Start () {
		startGame();	
	}
	public void startGame () {
		high = 1000;
		low = 1;
		mid = (high+low) / 2;
		high +=1;	
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
			SceneManager.LoadScene("Win");
		}
		else{
		mid =((high+low)/2);
		text.text = "My Guess is " + mid.ToString();
		maxGuesses--;
		}
	}

}
