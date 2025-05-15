using UnityEngine;
using UnityEngine.UI;


public class HpBar : MonoBehaviour
{
    public int maxHp = 100;  // 최대 체력 값
    public int currentHp;  // 현재 체력 값
    public Image HpBarImage;  // 체력바로 사용할 Image UI (Filled 타입 사용)


    void Start()
    {
        currentHp = maxHp;     
        Debug.Log(currentHp);       
    }
    // 체력을 최대값으로 회복시키는 함수
    public void ResetHp()
    {
        currentHp = maxHp;          // 체력을 최대값으로 설정
        UpdateHpBar();              // 체력바 UI 갱신
    }
    // 데미지를 받아 체력을 감소시키는 함수
    public void MinusHp(int damage)
    {
        currentHp -= damage;       
        currentHp = Mathf.Clamp(currentHp, 0, maxHp); 
        UpdateHpBar(); 
    }

    // 물약과 충돌 시 체력을 회복시키는 함수
    public void RecoveryHp(int recovery)
    {
        currentHp += recovery;        // 데미지만큼 체력 회복
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);   // 체력을 0 ~ maxHp 사이로 제한
        UpdateHpBar();              // 체력바 UI 갱신
    }

    // 체력바 UI를 현재 체력에 맞게 업데이트하는 함수
    void UpdateHpBar()
    {
        // fillAmount는 이미지의 채워지는 비율을 0.0f ~ 1.0f 사이로 설정
        // 예: 체력이 50%일 경우 fillAmount = 0.5f
        if (HpBarImage != null)
        {
            HpBarImage.fillAmount = (float)currentHp / maxHp;
        }
    }
    // private void Update()
    // {
    //     if (currentHp <= 0)
    //     {

    //         // 체력이 0 이하일 경우 게임 오버 처리
    //         Debug.Log("Game Over");

    //     }
    //     if (Input.GetMouseButtonDown(0))  // 0: 왼쪽 클릭
    //     {
    //         // 클릭 시 체력을 10만큼 감소
    //         MinusHp(10);  // 체력을 10만큼 줄이는 함수 호출
    //     }
    // }
}
