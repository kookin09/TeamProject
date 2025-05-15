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
        if (collision.gameObject.tag == "obstacle") //""태그의 물체와 충돌하였을 경우
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                hpBar.UpdateHp(10);
            }

        }
        else if (collision.gameObject.tag == "potion") //""태그의 물체와 충돌하였을 때
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
                Debug.Log("현재 점수: " + gameManager.nowScore);
            }
            Debug.Log("충돌");
            Destroy(collision.gameObject);
        }
    }
}