using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.HP > 0 && Player.Collider2D == (true))
        {
            Player.HP -= 10;
        }
        
    }
}
