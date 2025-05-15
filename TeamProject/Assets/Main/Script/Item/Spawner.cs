using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ItemPoolManager pool;

    // SmallCoin 생성위치
    private Vector3[] spawnPositions_small = new Vector3[]
    {
        new Vector3(7f, -3.5f, 0), 
        new Vector3(8f, -3.5f, 0),
        new Vector3(11f, -3.5f, 0),
        new Vector3(12f, -3.5f, 0),

        new Vector3(19f, -3.5f, 0),
        new Vector3(22f, -3.5f, 0),
        new Vector3(23f, -3.5f, 0),
        new Vector3(24f, -3.5f, 0),
        new Vector3(25f, -3.5f, 0),
        new Vector3(26f, -3.5f, 0),
        new Vector3(27f, -3.5f, 0),
        new Vector3(28f, -3.5f, 0),

        new Vector3(44.5f, -2.5f, 0), 
        
        new Vector3(60f, -3.5f, 0),
        new Vector3(64f, -3.5f, 0),
        
        new Vector3(72f, -0.0f, 0), 
        new Vector3(80f, -0f, 0),
        
        new Vector3(88.5f, -2.5f, 0),
        new Vector3(90.5f, -2.5f, 0),           
        new Vector3(91.5f, -2.5f, 0),        
        new Vector3(92.5f, -2.5f, 0),
        new Vector3(94.5f, -2.5f, 0),

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
        new Vector3(127.5f, -2.5f, 0),
        new Vector3(128.5f, -2.5f, 0),
        new Vector3(129.5f, -2.5f, 0),
        new Vector3(130.5f, -2.5f, 0),
        new Vector3(131.5f, -2.5f, 0),
        new Vector3(132.5f, -2.5f, 0),
        new Vector3(133.5f, -2.5f, 0),
        new Vector3(134.5f, -2.5f, 0),
        new Vector3(135.5f, -2.5f, 0),
    };

    // bigcoin 생성위치
    private Vector3[] spawnPositions_big = new Vector3[]
    {
        new Vector3(15, -2f, 0),
        new Vector3(84.5f, -2f, 0),
    };

    // bundle 생성위치
    private Vector3[] spawnPositions_bundle = new Vector3[]
    {
        new Vector3(102.5f, -3f, 0),
        new Vector3(105.5f, -3f, 0),

    };

    // gam 생성위치
    private Vector3[] spawnPositions_gam = new Vector3[]
    {
        new Vector3(20.5f, -2.35f, 0),
        new Vector3(29.5f, -2.35f, 0),
        new Vector3(41f, -1f, 0),
        new Vector3(50f, -3.2f, 0),
        new Vector3(51f, -3.2f, 0),
        new Vector3(52f, -3.2f, 0),
        new Vector3(53f, -3.2f, 0),

        new Vector3(58f, -2f, 0),
        new Vector3(62f, -2f, 0),
        new Vector3(66f, -2f, 0),

        new Vector3(72f, 0f, 0),
        new Vector3(76f, 0f, 0),
        new Vector3(80f, 0f, 0),

        new Vector3(102f, 2f, 0),
        new Vector3(103f, 2f, 0),
        new Vector3(104f, 2f, 0),
        new Vector3(105f, 2f, 0),
        new Vector3(106f, 2f, 0),

        new Vector3(120f, -2f, 0),
        new Vector3(121f, -2f, 0),
        new Vector3(122f, -2f, 0),
        new Vector3(123f, -2f, 0),
        new Vector3(124f, -2f, 0),
        new Vector3(125f, -2f, 0),

        new Vector3(150f, -2.35f, 0),
        new Vector3(152f, -2.35f, 0),
        new Vector3(154f, -2.35f, 0),
        new Vector3(156f, -2.35f, 0),
        new Vector3(158f, -2.35f, 0),
        new Vector3(160f, -2.35f, 0),
        new Vector3(162f, -2.35f, 0),
    };

    // potion 생성위치
    private Vector3[] spawnPositions_potion = new Vector3[]
    {
        new Vector3(109.5f, 3.9f, 0)
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
        foreach (var pos in spawnPositions_gam)
        {
            pool.GetFromPool(ObjectType.gam, pos);
        }
        foreach (var pos in spawnPositions_potion)
        {
            pool.GetFromPool(ObjectType.potion, pos);
        }

    }
}
