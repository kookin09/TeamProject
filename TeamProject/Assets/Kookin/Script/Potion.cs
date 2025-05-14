using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject potionPrefab; // 생성할 Potion 프리팹
    public float delay = 3f; // 생성 간격 (초)
    public float posY = -2f; // 생성 위치 Y를 고정
    public float posZ = 0f; // 생성 위치 Z
    public int spawnCount = 1;
    public float deleteDelayTime = 60f; // Gem이 사라지는 시간 (초)
    public int maxCount = 10; // 최대 생성 횟수

    private float lastPosX = 0f; // 이전 생성 위치 X값 저장
    private int Count = 0; // 현재까지 생성된 횟수

    void Start()
    {
        // 초기 x값 설정 (처음 생성 위치)
        lastPosX = 0f;
        // 일정 간격으로 Gem을 생성하는 코루틴 시작
        StartCoroutine(GemRoutine());
    }

    IEnumerator GemRoutine()
    {
        while (Count < maxCount)
        {
            yield return new WaitForSeconds(delay);
            Potions();
            Count++;
        }
    }
    void Potions()
    {
        for (int i = 0; i < 10; i++)
        {
            lastPosX += 30f; // 각 Gem마다 x 위치를 1씩 증가시킴
            Vector3 spawnPosition = new Vector3(lastPosX, posY, posZ);
            GameObject potion = Instantiate(potionPrefab, spawnPosition, Quaternion.identity);
            Destroy(potion, deleteDelayTime);
        }
    }
}
