using UnityEngine;
using UnityEngine.UI;


public class HpBar : MonoBehaviour
{
    public int maxHp = 100;         // �ִ� ü�� ��
    public int currentHp;     // ���� ü�� ��

    public Image HpBarImage;        // ü�¹ٷ� ����� Image UI (Filled Ÿ�� ���)

    // ���� ���� �� �ʱ�ȭ �Լ�
    void Start()
    {
        currentHp = maxHp;          // ���� ü���� �ִ� ü������ ����
        UpdateHpBar();              // ü�¹� UI ����
    }
    // ü���� �ִ밪���� ȸ����Ű�� �Լ�
    public void ResetHp()
    {
        currentHp = maxHp;          // ü���� �ִ밪���� ����
        UpdateHpBar();              // ü�¹� UI ����
    }
    // �������� �޾� ü���� ���ҽ�Ű�� �Լ�
    public void UpdateHp(int damage)
    {
        currentHp -= damage;        // ��������ŭ ü�� ����
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);   // ü���� 0 ~ maxHp ���̷� ����
        UpdateHpBar();              // ü�¹� UI ����
    }
    // ü�¹� UI�� ���� ü�¿� �°� ������Ʈ�ϴ� �Լ�
    void UpdateHpBar()
    {
        // fillAmount�� �̹����� ä������ ������ 0.0f ~ 1.0f ���̷� ����
        // ��: ü���� 50%�� ��� fillAmount = 0.5f
        HpBarImage.fillAmount = (float)currentHp / maxHp;
    }
    private void Update()
    {
        if (currentHp <= 0)
        {

            // ü���� 0 ������ ��� ���� ���� ó��
            Debug.Log("Game Over");

        }
        if (Input.GetMouseButtonDown(0))  // 0: ���� Ŭ��
        {
            // Ŭ�� �� ü���� 10��ŭ ����
            UpdateHp(10);  // ü���� 10��ŭ ���̴� �Լ� ȣ��
        }
    }
}
