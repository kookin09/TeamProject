using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HpBar hpBar = gameObject.GetComponent<HpBar>();
            hpBar.PlusHp(20);

            Debug.Log("체력 1/5 회복");

        }
            
        Destroy(this.gameObject);
        
    }

}
