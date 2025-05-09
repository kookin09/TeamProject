using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public Text highScoreText;
    public static GameManager Instance
    {
        get { return gameManager; }
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
    }

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", score);
        PlayerPrefs.Save();
    }
}
