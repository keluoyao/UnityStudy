using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockContrl : MonoBehaviour {
    public GameObject Rock;
    public GameObject[] Rocks;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.contacts[0].normal == Vector2.up)
        {
            AudioManager.Instance.PlaySound("顶破砖");
            foreach (GameObject rock in Rocks)
            {
                rock.transform.parent = null;
                Vector2 dir = rock.transform.position - transform.position;
                rock.AddComponent<Rigidbody2D>().AddForce(dir*900f);
                Destroy(rock,1f);
            }
            Destroy(gameObject);

        }
    }
}
