// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Spawner : MonoBehaviour
// {
//     // Start is called before the first frame update
//  public PoolManager pool;

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.G))
//         {
//             pool.GetFromPool(ObjectType.Gold, GetRandomPosition());
//         }
//         if (Input.GetKeyDown(KeyCode.M))
//         {
//             pool.GetFromPool(ObjectType.Magnet, GetRandomPosition());
//         }
//     }

//     Vector3 GetRandomPosition()
//     {
//         return new Vector3(Random.Range(-3f, 3f), Random.Range(-2f, 2f), 0f);
//     }
// }
