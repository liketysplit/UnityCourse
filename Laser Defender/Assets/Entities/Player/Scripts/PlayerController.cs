using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    public float speed = 15.0f;
    private float xmin, xmax, ymin, ymax;
    private float padding = .5f;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate = 0.1f;
    public float health = 300.0f;

    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftBounds = Camera.main.ViewportToWorldPoint(new Vector3( 0, 0,distance));
        Vector3 rightBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 upperBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 lowerBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));

        xmin = leftBounds.x + padding;
        xmax = rightBounds.x - padding;
        ymin = upperBounds.y + padding;
        ymax = lowerBounds.y - padding;
    }
	
	// Update is called once per frame
	void Update () {

            MoveWithArrows();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)){
            InvokeRepeating("Fire", 0.000001f, fireRate);
            }

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0)){
                CancelInvoke("Fire");
            }

    }

    void MoveWithArrows() {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {

            this.transform.position += new Vector3(-speed *Time.deltaTime, 0f, 0f);

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
        }

        //Player Restriction to the gamespace
        float tempX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(tempX, transform.position.y, transform.position.z);

        float tempY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(transform.position.x, tempY, transform.position.z);
    }


    void Fire() {
            Vector3 SP = transform.position + new Vector3(0, 1f, 0);
            GameObject beam = Instantiate(projectile, SP, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed,0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Player Hit");
        Projectile missle = col.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            Debug.Log("Hit");
            health -= missle.getDamage();
            missle.Hit();

            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
