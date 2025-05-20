using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HpBar hpBar = GameObject.Find("HpBar").GetComponentInChildren<HpBar>();
            hpBar.PlusHp(20);
        }
            
        Destroy(this.gameObject);
        
    }

}
