using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    private Button startButton;// ���� ���� ��ư
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Start").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        Debug.Log("Start Game");
        // SceneManager.LoadScene(); // ���� ���� �� �̸����� ��ü
    }

}
