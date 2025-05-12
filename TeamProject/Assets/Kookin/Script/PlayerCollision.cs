using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCollision : MonoBehaviour
{
    public HpBar hpbar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle") //""�±��� ��ü�� �浹�Ͽ��� ���
        {
            if(hpbar != null)
            {
                hpbar.UpdateHp(10);
            }
            Debug.Log("�浹�߽��ϴ�.");
        }
        else if (collision.gameObject.tag == "potion") //""�±��� ��ü�� �浹�Ͽ��� ��
        {
            if(hpbar != null)
            {
                hpbar.UpdateHp(20);
            }
            Destroy(collision.gameObject);
        }
    }
}
