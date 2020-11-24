using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinContrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up*150f);
        Destroy(gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
