using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCollision : MonoBehaviour
{
    public HpBar hpbar;
    public ScoreManager score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle") //""태그의 물체와 충돌하였을 경우
        {
            if(hpbar != null)
            {
                hpbar.UpdateHp(10);
            }
           
        }
        else if (collision.gameObject.tag == "potion") //""태그의 물체와 충돌하였을 때
        {
            if(hpbar != null)
            {
                hpbar.UpdateHp(20);
            }
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Gem")
        {
            if(score != null)
            {
            }
            Destroy(collision.gameObject);
        }
    }
}
