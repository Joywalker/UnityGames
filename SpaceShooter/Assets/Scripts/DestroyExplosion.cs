using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {

    public float time;
    private void Start()
    {
        GetComponent<AudioSource>().Play(); // this will play the explosion sound before destroying
        Destroy(gameObject,time);
    }
}
