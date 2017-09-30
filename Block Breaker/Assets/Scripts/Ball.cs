using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Transform;

public class Ball : MonoBehaviour {

    public Bumper bumper;
    public Vector3 paddleToBallVector;
    public bool hasStarted = false;

    // Use this for initialization
    void Start() {
        bumper = GameObject.FindObjectOfType<Bumper>();
        paddleToBallVector = this.transform.position - bumper.transform.position;
    }
    // Update is called once per frame
    void Update(){
        if(!hasStarted)
            transform.position = bumper.transform.position + paddleToBallVector;

        if (Input.GetMouseButtonDown(0) && !hasStarted){
            hasStarted = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f, 0.2f));
        //print(tweak);
        if (hasStarted){
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }

    }
}
