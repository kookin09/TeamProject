using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gemPrefab; // 생성할 Gem 프리팹
    public float spawnInterval = 1f; // 생성 간격 (초)
    public float spawnY = -3.5f; // 생성 위치 Y를 고정
    public float spawnZ = 0f; // 생성 위치 Z
    public int spawnCount = 3;

    private float lastXPosition = 0f; // 이전 생성 위치 X값 저장

    void Start()
    {
        // 초기 x값 설정 (처음 생성 위치)
        lastXPosition = 0f;
        // 일정 간격으로 Gem을 생성하는 코루틴 시작
        StartCoroutine(SpawnGemRoutine());
    }

    IEnumerator SpawnGemRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnGems();
        }
    }
    void SpawnGems()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            lastXPosition += 1f; // 각 Gem마다 x 위치를 1씩 증가시킴
            Vector3 spawnPosition = new Vector3(lastXPosition, spawnY, spawnZ);
            Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}