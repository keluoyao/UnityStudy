using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrl : MonoBehaviour {
    public int  Hp = 1;
    private Rigidbody2D rBody;
    private Animator ani;
    private SpriteRenderer sr;
    private bool isGround = false;
	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Hp <= 0)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            transform.Translate(transform.right * Time.deltaTime * 1 * horizontal);
            if (horizontal > 0)
            {
                sr.flipX = false;
            }
            if (horizontal < 0)
            {
                sr.flipX = true;
            }
            ani.SetBool("Run", true);
            //AudioManager.Instance.PlayMusic("地上");
        }
        else
        {
            ani.SetBool("Run",false);
        }
        if (Input.GetKeyDown(KeyCode.I) && isGround == true)
        {
            rBody.AddForce(Vector3.up*250);
            AudioManager.Instance.PlaySound("跳");
        }
        Debug.DrawRay(transform.position,Vector2.down*0.1f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,0.1f,1<<8);
        if (hit.collider != null)
        {
            isGround = true;
            ani.SetBool("Jump", false);
        }
        else
        {
            isGround = false;
            ani.SetBool("Jump",true);
        }
    }
    public void Die()
    {
        Hp--;
        if (Hp <= 0)
        {
            ani.SetTrigger("Die");
            Destroy(GetComponent<Collider2D>());
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlaySound("死亡1");
            rBody.velocity = Vector2.zero;
            rBody.AddForce(Vector2.up * 150f);
            Invoke("Die2",1f);
        }

    }
    void Die2()
    {
        AudioManager.Instance.PlaySound("死亡2");
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag=="Ground")
    //       isGround = true;
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isGround = false;
    //}
}
