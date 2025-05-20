using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text highScoreText;     // 최고 점수 텍스트 (숫자만 표시)
    [SerializeField] private Text currentScoreText;  // 현재 점수 텍스트 (숫자만 표시)
    [SerializeField] private Text currentGoldText;    // 현재 골드 텍스트 (숫자만 표시)
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GoldText;

    public int score = 0;
    public int gold = 0;
    public int highScore;

    private void Start()
    {

    }

    // 점수 추가
    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = $"Score : {score}";
    }

    // 골드 추가
    public void AddGold(int amount)
    {
        gold += amount;
        GoldText.text = $"Gold : {gold}";
    }


    // 최고 점수 갱신
    public void SaveHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
        }
    }
    public void ShowScore()
    {
        // highScoreText.text = highScore.ToString();
        currentScoreText.text = score.ToString();
        currentGoldText.text = gold.ToString();



    }

    // 점수 초기화
    public void ResetScore()
    {
        score = 0;
        currentScoreText.text = score.ToString();
    }

    // 현재 점수 반환
    public int GetScore(int score)
    {
        return score;
    }

    private void Update() // 테스트용
    {
        // S 키로 최고 점수 저장 테스트
        if (Input.GetKeyDown(KeyCode.S))
        {
            // SaveScore();
        }
    }


    // public void EndingScore()
    // {
    //     //최고 점수 불러와서 텍스트에 표시
    //     int highScore = PlayerPrefs.GetInt("BestScore", 0);
    //     highScoreText.text = highScore.ToString();

    //     //현재 점수 초기화 및 텍스트에 표시
    //     score = 0;
    //     currentScoreText.text = score.ToString();

    // }

}
