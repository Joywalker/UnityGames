using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour {

    // if other object collides with this, destroy other object
    public void OnTriggerExit(Collider other)
    {
        //check if enemy hits border
        if(other.tag != "Player")
        {
            Destroy(other.gameObject); // destroy enemy
        }
    }
}
