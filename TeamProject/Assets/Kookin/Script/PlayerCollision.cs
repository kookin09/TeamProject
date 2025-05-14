// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SocialPlatforms.Impl;

// public class PlayerCollision : MonoBehaviour
// {
//     public HpBar hpbar;
//     public ScoreManager score;

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.tag == "obstacle") //""�±��� ��ü�� �浹�Ͽ��� ���
//         {
//             if(hpbar != null)
//             {
//                 hpbar.MinusHp(10);
//             }
           
//         }
//         else if (collision.gameObject.tag == "potion") //""�±��� ��ü�� �浹�Ͽ��� ��
//         {
//             if(hpbar != null)
//             {
//                 hpbar.MinusHp(20);
//             }
//             Destroy(collision.gameObject);
//         }
//         else if(collision.gameObject.tag == "Gem")
//         {
//             if(score != null)
//             {
//             }
//             Destroy(collision.gameObject);
//         }
//     }
// }
