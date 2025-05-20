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
            UIManager uiManager = GameObject.Find("UIManager").GetComponentInChildren<UIManager>();
            uiManager.AddScore(1000);

        }
            
        Destroy(this.gameObject);
        
    }
}
    
