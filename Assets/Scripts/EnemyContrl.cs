using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContrl : MonoBehaviour {
    public int Hp = 1;
    private Animator ani;
    private Rigidbody2D rBody;
    //方向
    private int dir = 1;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Hp <= 0)
        { return; }
        //移动
        transform.Translate(Vector2.left*dir*0.2f*Time.deltaTime);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = -dir;
        if (collision.collider.tag == "Player")
        {
            if (collision.contacts[0].normal == Vector2.down)
            {
                //Debug.Log("蘑菇死亡");
                collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up*150f);
                Die();
            }
            else
            {
                // Debug.Log("玩家死亡");
                collision.collider.GetComponent<PlayerContrl>().Die();
            }
        }
    }
    public void Die()
    {
        Hp--;
        if (Hp <= 0)
        {
            Destroy(gameObject,1f);
            ani.SetTrigger("Die");
            AudioManager.Instance.PlaySound("踩敌人");
            GetComponent<Collider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
}
