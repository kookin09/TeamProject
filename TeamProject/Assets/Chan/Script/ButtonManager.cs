using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button startButton;   // ���� ���� ��ư
    private Button retryButton;   // �ٽ� ���� ��ư
    private Button exitButton;    // ���� ��ư

    void Start()
    {
        // ������ ��ư ������Ʈ�� ã�Ƽ� ��ư ������Ʈ �Ҵ�
        startButton = GameObject.Find("Start").GetComponent<Button>();
        retryButton = GameObject.Find("Retry").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();

        // Ŭ�� �̺�Ʈ�� �Լ� ����
        startButton.onClick.AddListener(StartGame);
        retryButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    // ���� ���� ��ư Ŭ�� �� ȣ��
    public void StartGame()
    {
        Debug.Log("Start Game");
       // SceneManager.LoadScene(); // ���� ���� �� �̸����� ��ü
    }

    // �ٽ� ���� ��ư Ŭ�� �� ȣ��
    public void RestartGame()
    {
        Debug.Log("Retry Game");
       // SceneManager.LoadScene(); // ���� �� �ٽ� �ε�
    }

    // ���� ���� ��ư Ŭ�� �� ȣ��
    public void ExitGame()
    {
        Debug.Log("Exit Game");

        UnityEditor.EditorApplication.isPlaying = false; // ����Ƽ �����Ϳ��� ����

        Application.Quit(); // ����� ���ӿ��� ����

    }
}
