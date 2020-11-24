using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStaticContrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="Player")
        {
            AudioManager.Instance.PlaySound("金币");
            Destroy(gameObject);
        }
    }
        
}
