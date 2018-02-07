using UnityEngine;
using System.Collections;

public class GOMover : MonoBehaviour
{
	public float speed;
	void Start ()
	{
        //move GO by velocity
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
