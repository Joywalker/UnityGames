﻿using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;
    public float padding = 1.0f;
    float xmin = -5;
    float xmax = 5;
    public float laserSpeed = 6f;
    public float fireRate = 2f;
    public float health = 300f;
    public GameObject projectile;
	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
        xmin = leftMost.x+padding;
        xmax = rightMost.x-padding;
    }

    void fireLaser()
    {
        Vector3 offSet = new Vector3(0, 1, 0);
        GameObject laser = Instantiate(projectile, transform.position + offSet, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("fireLaser", 0.0001f, fireRate);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("fireLaser");
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.left * speed * Time.deltaTime;    
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        // Restrict the player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileScript missile = collision.gameObject.GetComponent<ProjectileScript>();
        if (missile)
        {
            health -= missile.getDamageFunction();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
