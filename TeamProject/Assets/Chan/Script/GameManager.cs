using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public Text highScoreText;
    public Text ClearTime;
    private float startTime;
    private float clearTime;



    public void starttime()
    {
        
    }
    public void EndGame()
    {
        clearTime = Time.time - startTime;
        ShowClearTime();
    }

    private void ShowClearTime()
    {
        // 소수점 둘째 자리까지 표시
        ClearTime.text = $"{clearTime:F2}초";
    }

    private void Awake()
    {
        gameManager = this;
        
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("BestScore", 0);
        highScoreText.text =highScore.ToString();
        startTime = Time.time;
}

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", score);
        PlayerPrefs.Save();
    }
}
