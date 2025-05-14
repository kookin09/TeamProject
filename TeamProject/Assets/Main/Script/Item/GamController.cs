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
            ScoreManager scoreManager = gameObject.GetComponent<ScoreManager>();
            scoreManager.GetScore(1000);

            Debug.Log("½ºÄÚ¾î 1000Á¡ È¹µæ");

        }
            
        Destroy(this.gameObject);
        
    }
}
    
