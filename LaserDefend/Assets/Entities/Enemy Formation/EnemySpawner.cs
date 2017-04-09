using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    public float spawnDelay = 0.5f;
    public float padding = 1;

    private bool movingRight = true;
    private float xmax;
    private float xmin;

    // Use this for initialization
    void Start()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmin = leftBoundary.x;
        xmax = rightBoundary.x;

        var enemyGroup = transform;
        foreach (Transform singleEnemy in enemyGroup)
        {
            GameObject enemy = Instantiate(enemyPrefab, singleEnemy.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = singleEnemy;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
    // Update is called once per frame
    void Update()
    {
        //Restricts movement on X-axis
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);
        if (leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        } else if(rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }
    }
}
