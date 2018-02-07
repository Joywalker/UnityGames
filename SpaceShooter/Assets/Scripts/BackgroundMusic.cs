using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

	void Start ()
    {
        GetComponent<AudioSource>().Play(); // play backgroung music	
	}
}
