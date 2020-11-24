using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrl : MonoBehaviour {
    public Transform target;
    public float minX;
    public float maxX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        if (pos.x < minX)
        {
            pos.x = minX;
        }
        transform.position = pos;
	}
}
