using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AsteroidVFX
{
    public float health;
    public float damage;
    public float rotationFromLaser;
    public GameObject astExplosion;
}
[System.Serializable]
public class PlayerVFX
{
    public GameObject plExplosion;
}
public class LaserAsteroidDestroy : MonoBehaviour {

    public AsteroidVFX asteroid;
    public PlayerVFX player;
    private ScoreKeeper scoreKeeper;
    private AsteroidSpawner asteroidSpawner;
    private Quaternion defaultRotation = Quaternion.identity;
    private bool isAsteroidDestroyed() {return (asteroid.health <= 0) ? true : false; } //verify Asteroid HP
    private void doDamage() { asteroid.health -= asteroid.damage; } // hit asteroid and do damage
    private void InitializeComponents()
    {
        GameObject asteroidSpawnerGO = GameObject.FindWithTag("EnemySpawner");
        if (asteroidSpawnerGO != null)
        {
            asteroidSpawner = asteroidSpawnerGO.GetComponent<AsteroidSpawner>();
        }
        scoreKeeper = GameObject.Find("ScoreValues").GetComponent<ScoreKeeper>();
    }
    public void Start()
    {
        InitializeComponents();
    }

    public void OnTriggerEnter(Collider other)
    {
        //if asteroid hits border -> do nothing
        if (other.tag == "Border")
        {
            return;

        } else if (other.tag == "Player") // if collides with player
        {
            Instantiate(player.plExplosion, transform.position, defaultRotation);  //instantiate player explosion
            Instantiate(asteroid.astExplosion, transform.position, defaultRotation);
            //destroy both GO, player & asteroid
            Destroy(gameObject);
            Destroy(other.gameObject);
            asteroidSpawner.GameOver(); // print GameOver
        }
        doDamage(); //on collision with the player's laser, do damage
        if (isAsteroidDestroyed()) //verify if asteroid has 0 HP, destroy Asteroid
        {
            Destroy(other.gameObject); // destroy player laser shot
            Instantiate(asteroid.astExplosion, transform.position, defaultRotation);//intantiate explosion
            Destroy(gameObject); //destroy asteroid GO
            scoreKeeper.ScorePoints((int)(asteroid.damage * 10.0f)); // score points
        }
        else
        {
            Destroy(other.gameObject); // destroy laser shot GO
            gameObject.GetComponent<Rigidbody>().angularVelocity += Random.insideUnitSphere * asteroid.rotationFromLaser; // while Asteroid not destroyed, increase angVelocity
        }
    }
}
