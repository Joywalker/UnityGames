using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    public float damage = 100f;

    public float getDamageFunction()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
