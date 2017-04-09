using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float health = 150f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        ProjectileScript missile =  collision.gameObject.GetComponent<ProjectileScript>();
        if(missile)
        {
            health -= missile.getDamageFunction();
            missile.Hit();
            if ( health <= 0 )
            {
                Destroy(gameObject);
            }
        }
    }
}
