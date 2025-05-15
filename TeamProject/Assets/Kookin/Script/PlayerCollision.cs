using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerCollision : MonoBehaviour
{
    HpBar hpBar;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle") //""�±��� ��ü�� �浹�Ͽ��� ���
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                hpBar.UpdateHp(10);
            }

        }
        else if (collision.gameObject.tag == "potion") //""�±��� ��ü�� �浹�Ͽ��� ��
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                hpBar.RecoveryHp(10);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "gem")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                gameManager.UpdateScore(100);
                Debug.Log("���� ����: " + gameManager.nowScore);
            }
            Debug.Log("�浹");
            Destroy(collision.gameObject);
        }
    }
}