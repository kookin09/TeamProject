using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject potionPrefab; // ������ Potion ������
    public float delay = 3f; // ���� ���� (��)
    public float posY = -2f; // ���� ��ġ Y�� ����
    public float posZ = 0f; // ���� ��ġ Z
    public int spawnCount = 1;
    public float deleteDelayTime = 60f; // Gem�� ������� �ð� (��)
    public int maxCount = 10; // �ִ� ���� Ƚ��

    private float lastPosX = 0f; // ���� ���� ��ġ X�� ����
    private int Count = 0; // ������� ������ Ƚ��

    void Start()
    {
        // �ʱ� x�� ���� (ó�� ���� ��ġ)
        lastPosX = 0f;
        // ���� �������� Gem�� �����ϴ� �ڷ�ƾ ����
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
            lastPosX += 30f; // �� Gem���� x ��ġ�� 1�� ������Ŵ
            Vector3 spawnPosition = new Vector3(lastPosX, posY, posZ);
            GameObject potion = Instantiate(potionPrefab, spawnPosition, Quaternion.identity);
            Destroy(potion, deleteDelayTime);
        }
    }
}
