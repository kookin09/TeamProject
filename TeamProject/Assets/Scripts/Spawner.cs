using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public PoolManager pool;

    private Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(7, 3.5f, 0),
        new Vector3(8, 3.5f, 0),
        new Vector3(11, 3.5f, 0),
        new Vector3(12, 3.5f, 0),
    };

    void Start()
    {
        foreach (var pos in spawnPositions)
        {
            pool.GetFromPool(ObjectType.smallCoin, pos);
        }
    }
}
