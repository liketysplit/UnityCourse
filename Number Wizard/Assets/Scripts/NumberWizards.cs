using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {
	public static int high = 1000, low = 1, mid = (high+low) / 2;
	// Use this for initialization
	void Start () {
	
		startGame();
		
	}
	void startGame () {
	
		high = 1000;
		low = 1;
		mid = (high+low) / 2;
		
		print("=====================================================");
		print("=====================New Game========================");
		print("=====================================================");
		print("Welcome to number Wizard!");
		print("Pick a number in your head. Don't tell me.");
		print("The highest number you can pick is: " +  high);
		print("The lowest number you can pick is:  " +  low);
		print("Is your number higher or lower than " + mid + "?");
		print("Higher = Up; Lower = Down");
		
		high +=1;
		
	}
	
	void nextGuess () {
	
		mid =(high+low)/2;
		print("Is your number higher or lower than " + mid + "?");
		print("Higher = Up; Lower = Down");
	
	}
	// Update is called \once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			low = mid;
			nextGuess ();

		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)){
			high = mid;
			nextGuess ();
		}
		else if(Input.GetKeyDown(KeyCode.Return)){
			print ("I won! Game Over!");
			startGame();
			
		}
	}
}
