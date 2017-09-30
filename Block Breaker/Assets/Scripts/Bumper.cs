using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bumper : MonoBehaviour {


    public bool autoplay = false;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoplay)
            AutmatedPlay();
        else
            MoveWithMouse();
    }

    void MoveWithMouse() {
        //create a position for the paddle
        Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);
        //Grab the mouse position
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        //Paddle restraints 
        paddlePosition.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
        //set the paddle to the mouse location
        this.transform.position = paddlePosition;
    }

    void AutmatedPlay() {
        //create a position for the paddle
        Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0f);
        //Grab the ball position
        Vector3 ballPosition = ball.transform.position;
        //Paddle restraints to the ball
        paddlePosition.x = Mathf.Clamp(ballPosition.x, 1f, 15f);
        //set the paddle to the ball
        this.transform.position = paddlePosition;

    }
}
