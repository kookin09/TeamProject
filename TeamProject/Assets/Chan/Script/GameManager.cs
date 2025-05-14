using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ� (�ٸ� ��ũ��Ʈ���� GameManager.Instance�� ���� ����)
    public static GameManager Instance { get; private set; }

   
    public Text ClearTime;      // Ŭ���� �ð� ǥ�ÿ� UI Text

    private float startTime;    // ���� ���� �ð� ����
    private float clearTime;    // Ŭ���� �� �ɸ� �ð� ����
    private bool gameEnded = false;  // ���� Ŭ���� ���� üũ

    private void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� �Ѿ�� ������
        }
        else
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� ����
        }
    }

    void Start()
    {      
        if (SceneManager.GetActiveScene().name != "GameOver")
        {
            StartTimer();
        }
    }

    void Update()
    {
        // ������ ���� ������ �ʾҰ�, �׿��� ���� �ƴ� ���� �ð� ������Ʈ
        if (!gameEnded && SceneManager.GetActiveScene().name != "GameOver")
        {
            float elapsed = Time.time - startTime;        // ��� �ð� ���
            ClearTime.text = FormatTime(elapsed);         // �ؽ�Ʈ�� ǥ��
        }
    }

    // ���� ���� �ð� ����
    public void StartTimer()
    {
        startTime = Time.time;
        gameEnded = false;
    }

    // ���� Ŭ���� ó��
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver"); // GameOver ������ �̵�
        if (gameEnded) return; // �ߺ� ���� ����

        clearTime = Time.time - startTime; // Ŭ���� ������ ��� �ð� ����
        gameEnded = true;

        ShowClearTime();       // Ŭ���� �ð� �ؽ�Ʈ ǥ��
    }

    // Ŭ���� �ð� ǥ�� + ���� �Ͻ� ����
    private void ShowClearTime()
    {
        ClearTime.text = $"{FormatTime(clearTime)}";
        Time.timeScale = 0f; // ���� ���� (�Ͻ� ����)
    }

    // float �� ���� �ð��� "��:��" �������� �ٲ��ִ� �Լ�
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f); // �� ����
        int seconds = Mathf.FloorToInt(time % 60f); // �� ����
        return $"{minutes:00}��:{seconds:00}��";        // ��: 01:05
    }

    // ���� ���� ó�� (�� ��ȯ ��)
    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver"); // GameOver ������ �̵�
    }

    // ���� ����
  
}
