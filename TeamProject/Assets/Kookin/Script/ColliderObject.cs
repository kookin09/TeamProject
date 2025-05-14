using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Assets.Kookin.Script
{
    public class ColliderObject : MonoBehaviour
    {
        Player player;
        HpBar hpBar; //HpBar 스크립트의 객체를 담을 변수
        GameManager gameManager; //GameManager 스크립트의 객체를 담을 변수

        private void Start()
        {
            hpBar = GameObject.Find("HpBar").GetComponentInChildren<HpBar>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision) 
        {

            if (collision.gameObject.tag == "Player") //""태그의 물체와 충돌하였을 경우
            {
                player = collision.gameObject.GetComponent<Player>();
                Debug.Log("Player와 부딪힘");
                if (hpBar.currentHp > 0) //체력이 0보다 클 때
                {
                    hpBar.MinusHp(10); //hp 10감소
                    player.Damage();

                }
                else
                {
                    gameManager.GameOver(); //반대의 경우 게임종료
                }
            }
        }
    }
}