using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ColliderObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "") //""�±��� ��ü�� �浹�Ͽ��� ���
        {
            if(hp > 0) //ü���� 0���� Ŭ ��
            {
                hp -= 10; // ü�� 10����
            }
            else
            {
                GameOver(); //�ݴ��� ��� ��������
            }
        }
        else if (collision.gameObject.tag == "") //""�±��� ��ü�� �浹�Ͽ��� ��
        {
            Hp += 10; //hp 10ȸ��
            Hp = Mathf.Clamp(Hp, 0, 100); // ü�� �ִ� �ּҰ�����
        }
        else if (collision.gameObject.tag == "")
        {
            Score += 1000;
        }
    }
}
