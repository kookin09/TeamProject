using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PoolManager pool;

    // SmallCoin이 생성될 위치
    private Vector3[] spawnPositions_small = new Vector3[]
    {
        new Vector3(7f, -3.5f, 0), //땅 1칸. y값 -3.5
        new Vector3(8f, -3.5f, 0),
        new Vector3(11f, -3.5f, 0),
        new Vector3(12f, -3.5f, 0),

        new Vector3(19f, -3.5f, 0),
        new Vector3(20f, -3.5f, 0),
        new Vector3(21f, -3.5f, 0),
        new Vector3(22f, -3.5f, 0),

        new Vector3(23f, -3.5f, 0),
        new Vector3(24f, -3.5f, 0),
        new Vector3(25f, -3.5f, 0),
        new Vector3(26f, -3.5f, 0),
        new Vector3(27f, -3.5f, 0),
        new Vector3(28f, -3.5f, 0),
        new Vector3(29f, -3.5f, 0),
        new Vector3(30f, -3.5f, 0),

        new Vector3(44.5f, -2.5f, 0), //땅 2칸. y값 -2.5
        
        new Vector3(60f, -3.5f, 0),
        new Vector3(64f, -3.5f, 0),
        
        new Vector3(72.5f, -0.8f, 0), //땅 3칸 + 장애물. y값 -0.8
        new Vector3(75.5f, -0.8f, 0),
        new Vector3(79, -0.8f, 0),
        
        new Vector3(88.5f, -2.5f, 0),
        new Vector3(89.5f, -2.5f, 0),
        new Vector3(90.5f, -2.5f, 0),           
        new Vector3(91.5f, -2.5f, 0),        
        new Vector3(92.5f, -2.5f, 0),
        new Vector3(94.5f, -2.5f, 0),
        new Vector3(98f, -2.5f, 0),
        new Vector3(100.5f, -2.5f, 0),
        new Vector3(102.5f, -2.5f, 0),
        new Vector3(108.5f, -2.5f, 0),
        new Vector3(110.5f, -2.5f, 0),                           
        new Vector3(112.5f, -2.5f, 0),
        new Vector3(114.5f, -2.5f, 0),
        new Vector3(116.5f, -2.5f, 0),
        new Vector3(118.5f, -2.5f, 0),
        
        new Vector3(126.5f, -2.5f, 0),
        new Vector3(127.5f, -2.5f, 0),
        new Vector3(128.5f, -2.5f, 0),
        new Vector3(129.5f, -2.5f, 0),
        new Vector3(130.5f, -2.5f, 0),
        new Vector3(131.5f, -2.5f, 0),
        new Vector3(132.5f, -2.5f, 0),
        
        new Vector3(126.5f, -2.5f, 0),

        
    };


    // bigCoin이 생성될 위치
    private Vector3[] spawnPositions_big = new Vector3[]
    {
        new Vector3(15, -2f, 0),
        new Vector3(84.5f, -2f, 0),
    };

    // CoinBundle이 생성될 위치
    private Vector3[] spawnPositions_bundle = new Vector3[]
    {
        new Vector3(191.5f, -3f, 0),
        new Vector3(194.5f, -3f, 0),

    };



    void Start()
    {
        foreach (var pos in spawnPositions_small)
        {
            pool.GetFromPool(ObjectType.smallCoin, pos);
        }
        foreach (var pos in spawnPositions_big)
        {
            pool.GetFromPool(ObjectType.bigCoin, pos);
        }
        foreach (var pos in spawnPositions_bundle)
        {
            pool.GetFromPool(ObjectType.coinBundle, pos);
        }
    }
}
