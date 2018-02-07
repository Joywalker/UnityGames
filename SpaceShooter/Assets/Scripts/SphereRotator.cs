using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotator : MonoBehaviour {

    public float rot;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rot;
    }
}
