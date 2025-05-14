using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gemPrefab; // ������ Gem ������
    public float spawnInterval = 1f; // ���� ���� (��)
    public float spawnY = -3.5f; // ���� ��ġ Y�� ����
    public float spawnZ = 0f; // ���� ��ġ Z
    public int spawnCount = 3;

    private float lastXPosition = 0f; // ���� ���� ��ġ X�� ����

    void Start()
    {
        // �ʱ� x�� ���� (ó�� ���� ��ġ)
        lastXPosition = 0f;
        // ���� �������� Gem�� �����ϴ� �ڷ�ƾ ����
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
            lastXPosition += 1f; // �� Gem���� x ��ġ�� 1�� ������Ŵ
            Vector3 spawnPosition = new Vector3(lastXPosition, spawnY, spawnZ);
            Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}