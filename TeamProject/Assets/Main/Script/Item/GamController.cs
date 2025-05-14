using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class GamController : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ScoreManager scoreManager = gameObject.GetComponent<ScoreManager>();
            // scoreManager.GetScore(1000);

            Debug.Log("스코어 1000점 획득");

        }
            
        Destroy(this.gameObject);
        
    }
}
    
