// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SocialPlatforms.Impl;

// public class ColliderObject : MonoBehaviour
// {
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.tag == "") //""태그의 물체와 충돌하였을 경우
//         {
//             if(hp > 0) //체력이 0보다 클 때
//             {
//                 hp -= 10; // 체력 10감소
//             }
//             else
//             {
//                 GameOver(); //반대의 경우 게임종료
//             }   
//         }
//         else if (collision.gameObject.tag == "") //""태그의 물체와 충돌하였을 때
//         {
//             Hp += 10; //hp 10회복
//             Hp = Mathf.Clamp(Hp, 0, 100); // 체력 최대 최소값설정
//         }
//         else if (collision.gameObject.tag == "")
//         {
//             Score += 1000;
//         }
//     }
// }
