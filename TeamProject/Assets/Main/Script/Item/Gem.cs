using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gemPrefab; // 생성할 Gem 프리팹
    public float delay = 0.5f; // 생성 간격 (초)
    public float posY = -3.5f; // 생성 위치 Y를 고정
    public float posZ = 0f; // 생성 위치 Z
    public int spawnCount = 20;
    public float deleteDelayTime = 60f; // Gem이 사라지는 시간 (초)
    public int maxcount = 20; // 최대 생성 횟수

    private float lastPosX = 0f; // 이전 생성 위치 X값 저장
    private int Count = 0; // 현재까지 생성된 횟수

    void Start()
    {
        lastPosX = 0f;
        StartCoroutine(GemRoutine());
    }

    IEnumerator GemRoutine()
    {
        while (Count < maxcount)
        {
            yield return new WaitForSeconds(delay);
            Gems();
            Count++;
            deleteDelayTime += 5;
        }
    }

    void Gems()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            lastPosX += 1f; // 각 Gem마다 x 위치를 1씩 증가시킴
            Vector3 spawnPosition = new Vector3(lastPosX, posY, posZ);
            GameObject gem = Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
            Destroy(gem, deleteDelayTime);
        }
    }
}