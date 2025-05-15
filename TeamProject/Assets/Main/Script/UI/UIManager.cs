using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text highScoreText;     // �ְ� ���� �ؽ�Ʈ (���ڸ� ǥ��)
    public Text currentScoreText;  // ���� ���� �ؽ�Ʈ (���ڸ� ǥ��)
    public Text currentGoldText;    // ���� ��� �ؽ�Ʈ (���ڸ� ǥ��)
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GoldText;

    private int score = 0;
    private int gold = 0;

    // private void Start()
    // {
    //     // �ְ� ���� �ҷ��ͼ� �ؽ�Ʈ�� ǥ��
    //     int highScore = PlayerPrefs.GetInt("BestScore", 0);
    //     highScoreText.text = highScore.ToString();

    //     // ���� ���� �ʱ�ȭ �� �ؽ�Ʈ�� ǥ��
    //     score = 0;
    //     currentScoreText.text = score.ToString();
    // }

    // ���� �߰�
    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = $"Score : {score}";
    }
    public void AddGold(int amount)
    {
        gold += amount;
        GoldText.text = $"Gold : {gold}";
        Debug.Log(gold);

    }
    public void SaveScore()
    {
        currentScoreText.text = score.ToString();
        currentGoldText.text = gold.ToString();
        GoldText.text = $"Gold : {gold}";
        Debug.Log(gold);

    }



    // // �ְ� ���� ����
    // public void SaveScore()
    // {
    //     int highScore = PlayerPrefs.GetInt("BestScore", 0);

    //     if (score > highScore)
    //     {
    //         PlayerPrefs.SetInt("BestScore", score);
    //         PlayerPrefs.Save();
    //         highScoreText.text = score.ToString();
    //     }
    // }

    // ���� �ʱ�ȭ
    public void ResetScore()
    {
        score = 0;
        currentScoreText.text = score.ToString();
    }

    // ���� ���� ��ȯ
    public int GetScore(int score)
    {
        return score;
    }

    private void Update() // �׽�Ʈ��
    {
        // S Ű�� �ְ� ���� ���� �׽�Ʈ
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveScore();
        }
    }
}
