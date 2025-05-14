using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gemPrefab; // ������ Gem ������
    public float delay = 0.5f; // ���� ���� (��)
    public float posY = -3.5f; // ���� ��ġ Y�� ����
    public float posZ = 0f; // ���� ��ġ Z
    public int spawnCount = 20;
    public float deleteDelayTime = 60f; // Gem�� ������� �ð� (��)
    public int maxcount = 20; // �ִ� ���� Ƚ��

    private float lastPosX = 0f; // ���� ���� ��ġ X�� ����
    private int Count = 0; // ������� ������ Ƚ��

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
            lastPosX += 1f; // �� Gem���� x ��ġ�� 1�� ������Ŵ
            Vector3 spawnPosition = new Vector3(lastPosX, posY, posZ);
            GameObject gem = Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
            Destroy(gem, deleteDelayTime);
        }
    }
}