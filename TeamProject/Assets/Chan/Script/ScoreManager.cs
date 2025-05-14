using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text highScoreText;     // 최고 점수 텍스트 (숫자만 표시)
    public Text currentScoreText;  // 현재 점수 텍스트 (숫자만 표시)

    private int score = 0;

    private void Start()
    {
        // 최고 점수 불러와서 텍스트에 표시
        int highScore = PlayerPrefs.GetInt("BestScore", 0);
        highScoreText.text = highScore.ToString();

        // 현재 점수 초기화 및 텍스트에 표시
        score = 0;
        currentScoreText.text = score.ToString();
    }

    // 점수 추가
    public void AddScore(int amount)
    {
        score += amount;
        currentScoreText.text = score.ToString();
    }

    // 최고 점수 갱신
    public void SaveScore()
    {
        int highScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString();
        }
    }

    // 점수 초기화
    public void ResetScore()
    {
        score = 0;
        currentScoreText.text = score.ToString();
    }

    // 현재 점수 반환
    public int GetScore()
    {
        return score;
    }

    private void Update() // 테스트용
    {
        // 스페이스바 누르면 점수 1점 추가
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(1);
        }

        // S 키로 최고 점수 저장 테스트
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveScore();
        }
    }
}
