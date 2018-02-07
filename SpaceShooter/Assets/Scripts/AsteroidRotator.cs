using UnityEngine;
using System.Collections;

public class AsteroidRotator : MonoBehaviour 
{
	public float rot;
	void Start ()
	{
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rot;
	}
}