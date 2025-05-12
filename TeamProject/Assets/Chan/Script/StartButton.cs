using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    private Button startButton;// 게임 시작 버튼
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Start").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        Debug.Log("Start Game");
        // SceneManager.LoadScene(); // 메인 게임 씬 이름으로 교체
    }

}
