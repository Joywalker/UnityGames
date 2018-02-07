using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public float scrollspeed;
    void Update()
    {
        //get the BG object
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material material = mr.sharedMaterial;

        //set offset value as the BG picture
        Vector2 offset = material.mainTextureOffset;

        offset.y += Time.deltaTime * scrollspeed; // set new offset
        material.mainTextureOffset = offset;




    }
}
