using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ColliderObject : MonoBehaviour
{
    HpBar hpBar; //HpBar ��ũ��Ʈ�� ��ü�� ���� ����
    GameManager gameManager ; //GameManager ��ũ��Ʈ�� ��ü�� ���� ����
    private void Start()
    {
        hpBar = GameObject.Find("HpBar").GetComponent<HpBar>(); //HpBar ��ũ��Ʈ�� ��ü�� ã�´�
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "") //""�±��� ��ü�� �浹�Ͽ��� ���
        {
            if(hpBar.currentHp >= 0) //ü���� 0���� Ŭ ��
            {
                hpBar.UpdateHp(10); //hp 10����
            }
            else
            {
                 gameManager.GameOver(); //�ݴ��� ��� ��������
            }
        }
        else if (collision.gameObject.tag == "") //""�±��� ��ü�� �浹�Ͽ��� ��
        {
            hpBar.currentHp += 10; //hp 10ȸ��
            
        }
        else if (collision.gameObject.tag == "")
        {
           //Score += 1000;
        }
    }
}
