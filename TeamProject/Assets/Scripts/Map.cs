using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("GroundCheck"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            GameManager gameManager = FindObjectOfType<GameManager>();
            player.Death();
            gameManager.EndGame();
        }
    }

}
