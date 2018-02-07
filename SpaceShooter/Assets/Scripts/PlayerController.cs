using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
[System.Serializable]
public class ShipMovement
{
    public float Speed, tilt;
}

[System.Serializable]
public class PlayerLaserShot
{
    public GameObject shot;
    public Transform shotSpawnOne;
    public Transform shotSpawnTwo;
    public float  fireRate;
}

public class PlayerController : MonoBehaviour {

    public Boundary boundary;
    public ShipMovement shipMovement;
    public PlayerLaserShot playerShot;
    private float nextFire;
    private void Update()
    {
        //spawn next shot after a certain time interval
        if (Input.GetButton("Fire1") && Time.time > nextFire) // check if player shoots
        { 
            nextFire = Time.time + playerShot.fireRate; //this will set the interval between shots
            //Instantiate player projectiles(shots)
            Instantiate(playerShot.shot, playerShot.shotSpawnOne.position, playerShot.shotSpawnOne.rotation);
            Instantiate(playerShot.shot, playerShot.shotSpawnTwo.position, playerShot.shotSpawnTwo.rotation);                                          
            GetComponent<AudioSource>().Play(); //this will play shot fx.
        }
    }
    private void FixedUpdate()
    {

        // set player movement by Speed
        Vector3 playerMovement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.transform.position = playerMovement;

        rBody.velocity = playerMovement;
        //restrict the player's rb to get over boundaries
        rBody.position = new Vector3(
            Mathf.Clamp(rBody.position.x, boundary.xMin,boundary.xMax),
            0.0f,
            Mathf.Clamp(rBody.position.z, boundary.zMin,boundary.zMax)
            );
        
        

        //add player tilt when steering to left/right
        rBody.rotation = Quaternion.Euler(0.0f, 0.0f, rBody.velocity.x * -shipMovement.tilt);
    }
}
