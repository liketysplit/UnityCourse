using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enBehav : MonoBehaviour {
    public GameObject projectile;
    public float projectileSpeed =10;
    public float fireRate = 0.5f;
    public float health = 300.0f;

    void OnTriggerEnter2D(Collider2D col) {
        Projectile missle = col.gameObject.GetComponent<Projectile>();
        if (missle){
            Debug.Log("Hit");
            health -= missle.getDamage();
            missle.Hit();

            if (health <= 0)
                Destroy(gameObject);
        }
    }

    void Fire()
    {
        Vector3 SP = transform.position + new Vector3(0, -1f, 0);
        GameObject missle = Instantiate(projectile, SP, Quaternion.identity) as GameObject;
        missle.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }

    void Update() {
        float prob = Time.deltaTime * fireRate;
        if(Random.value < prob)
            Fire();
     
    }
}
