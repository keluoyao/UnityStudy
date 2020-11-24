using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour {
    public int Hp = 5;
    public GameObject gopre;
    public string sound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag=="Player"&&collision.contacts[0].normal==Vector2.up)
        {
            if (Hp > 0)
            {
                Hp--;
                AudioManager.Instance.PlaySound(sound);
                Instantiate(gopre, transform.position, Quaternion.identity);
                if (Hp <= 0)
                {
                    GetComponent<Animator>().SetTrigger("Die");
                }
            }
            else
            {
                AudioManager.Instance.PlaySound("顶砖石块");
            }
        }
    }
}
