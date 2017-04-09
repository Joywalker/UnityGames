using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBK : MonoBehaviour {

    private float parralax = 2f;
	void Update () {


        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material material = mr.material;

        Vector2 offset = material.mainTextureOffset;

        offset.y += Time.deltaTime / 10f;
        material.mainTextureOffset = offset;
	}
}
