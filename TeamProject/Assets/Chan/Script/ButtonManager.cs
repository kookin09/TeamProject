using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button startButton;   // 게임 시작 버튼
    private Button retryButton;   // 다시 시작 버튼
    private Button exitButton;    // 종료 버튼

    void Start()
    {
        // 각각의 버튼 오브젝트를 찾아서 버튼 컴포넌트 할당
        startButton = GameObject.Find("Start").GetComponent<Button>();
        retryButton = GameObject.Find("Retry").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();

        // 클릭 이벤트에 함수 연결
        startButton.onClick.AddListener(StartGame);
        retryButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // 게임 시작 버튼 클릭 시 호출
    public void StartGame()
    {
        Debug.Log("Start Game");
       // SceneManager.LoadScene(); // 메인 게임 씬 이름으로 교체
    }

    // 다시 시작 버튼 클릭 시 호출
    public void RestartGame()
    {
        Debug.Log("Retry Game");
       // SceneManager.LoadScene(); // 현재 씬 다시 로드
    }

    // 게임 종료 버튼 클릭 시 호출
    public void ExitGame()
    {
        Debug.Log("Exit Game");

        UnityEditor.EditorApplication.isPlaying = false; // 유니티 에디터에서 종료

        Application.Quit(); // 빌드된 게임에서 종료

    }
}
