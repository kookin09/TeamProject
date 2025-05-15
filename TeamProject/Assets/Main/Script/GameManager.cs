using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스 (다른 스크립트에서 GameManager.Instance로 접근 가능)
    public static GameManager Instance { get; private set; }

   
    public Text ClearTime;      // 클리어 시간 표시용 UI Text
    private float startTime;    // 게임 시작 시간 저장
    private float clearTime;    // 클리어 시 걸린 시간 저장
    private bool gameEnded = false;  // 게임 클리어 여부 체크

    UIManager uiManager;

    private void Awake()
    {
        Time.timeScale = 0;
        // 싱글톤 패턴 구현
        if (Instance == null)
        
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 유지됨
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 제거
        }

    }

    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        if (SceneManager.GetActiveScene().name != "GameOver")
        {
            if (SceneManager.GetActiveScene().name != "GameStart")
                StartTimer();
        }
    }

    void Update()
    {
        // 게임이 아직 끝나지 않았고, 겜오버 씬이 아닐 때만 시간 업데이트
        // if (!gameEnded && SceneManager.GetActiveScene().name != "GameOver")
        // {
        //     float elapsed = Time.time - startTime;        // 경과 시간 계산
        //     ClearTime.text = FormatTime(elapsed);         // 텍스트로 표시
        // }
    }

    // 게임 시작 시간 저장
    public void StartTimer()
    {
        startTime = Time.time;
        gameEnded = false;
    }

    // 게임 클리어 처리
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver"); // GameOver 씬으로 이동
        if (gameEnded) return; // 중복 실행 방지

        clearTime = Time.time - startTime; // 클리어 시점의 경과 시간 저장
        gameEnded = true;

        ShowClearTime();       // 클리어 시간 텍스트 표시
    }

    // 클리어 시간 표시 + 게임 일시 정지
    private void ShowClearTime()
    {
        // ClearTime.text = $"{FormatTime(clearTime)}";
        // Time.timeScale = 0f; // 게임 정지 (일시 정지)
    }

    // float 초 단위 시간을 "분:초" 형식으로 바꿔주는 함수
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f); // 분 단위
        int seconds = Mathf.FloorToInt(time % 60f); // 초 단위
        return $"{minutes:00}분:{seconds:00}초";        // 예: 01:05
    }

    // 게임 오버 처리 (씬 전환 등)
    public void GameOver()
    {
        Debug.Log("Game Over");
        // SceneManager.LoadScene("GameOver"); // GameOver 씬으로 이동
        uiManager.SaveScore();
    }

    // 점수 저장
  
}
