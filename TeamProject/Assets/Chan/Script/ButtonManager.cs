using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
   
    private Button retryButton;   // �ٽ� ���� ��ư
    private Button exitButton;    // ���� ��ư

    void Start()
    {
        // ������ ��ư ������Ʈ�� ã�Ƽ� ��ư ������Ʈ �Ҵ�
       
        retryButton = GameObject.Find("Retry").GetComponent<Button>();
        exitButton = GameObject.Find("Exit").GetComponent<Button>();

        // Ŭ�� �̺�Ʈ�� �Լ� ����
        
        retryButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
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
