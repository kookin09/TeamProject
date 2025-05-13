using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Assets.Kookin.Script
{
    public class ColliderObject : MonoBehaviour
    {
        HpBar hpBar; //HpBar 스크립트의 객체를 담을 변수
        GameManager gameManager; //GameManager 스크립트의 객체를 담을 변수
        private void Start()
        {
            hpBar = GameObject.Find("HpBar").GetComponent<HpBar>(); //HpBar 스크립트의 객체를 찾는다

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "") //""태그의 물체와 충돌하였을 경우
            {
                if (hpBar.currentHp >= 0) //체력이 0보다 클 때
                {
                    hpBar.UpdateHp(10); //hp 10감소
                }
                else
                {
                    gameManager.GameOver(); //반대의 경우 게임종료
                }
            }
            else if (collision.gameObject.tag == "") //""태그의 물체와 충돌하였을 때
            {
                hpBar.currentHp += 10; //hp 10회복

            }
            else if (collision.gameObject.tag == "")
            {
                //Score += 1000;
            }
        }
    }
}