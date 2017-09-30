using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 1.5f;
    public float sDelay = 0.5f;

    private float xmin, xmax, ymin, ymax;
    private bool movingRight = false;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
    }

    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftBounds.x;
        xmax = rightBounds.x;

        spawnUntilFull();

    }

    void Move(){

        if (!movingRight){
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        if (movingRight){
            this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        float rightEdge = transform.position.x + (0.5f * width);
        float leftEdge = transform.position.x - (0.5f * width);

        if (leftEdge < xmin)
            movingRight = true;
        else if (rightEdge > xmax) 
            movingRight = false;

    }

    // Update is called once per frame
    void Update () {

        Move();

        if (AllMemDead()) {
            spawnUntilFull();
        }

    }

    void spawnUntilFull() {
        Transform freePos = nextFreePosition();
        if (freePos) { 
            GameObject enemy = Instantiate(enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePos;
        }
        if(nextFreePosition())
            Invoke("spawnUntilFull", sDelay);


    }

    bool AllMemDead(){
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0)
            return false;
        }
        return true;
    }

    Transform nextFreePosition(){
        foreach (Transform childPositionGameObject in transform){
            if (childPositionGameObject.childCount == 0)
                return childPositionGameObject;
        }
        return null;
    }

    void spawn() {

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child.transform;
        }
    }
}
