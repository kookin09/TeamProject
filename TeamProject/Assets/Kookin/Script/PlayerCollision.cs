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
        // hpBar를 찾거나 할당
        hpBar = FindObjectOfType<HpBar>();
        if (hpBar == null)
        {
            Debug.LogError("HpBar를 찾을 수 없습니다. 씬에 HpBar 오브젝트가 있는지 확인하세요.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && hpBar != null)
            {
                hpBar.UpdateHp(10);
            }
        }
        else if (collision.gameObject.tag == "potion")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && hpBar != null)
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
