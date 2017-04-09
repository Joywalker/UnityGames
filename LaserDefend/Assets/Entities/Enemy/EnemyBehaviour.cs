using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject projectile;
    public float projectileSpeed = 10f;
    public float health = 150f;
    public float shotsPerSecond = 0.5f;

    void Update()
    {
        float probability = shotsPerSecond * Time.deltaTime;
        if(Random.value < probability)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Vector3 startPos = transform.position + new Vector3(0, -1, 0);
        GameObject missile = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
    private void Hit()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
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
