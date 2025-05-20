using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Text highScoreText;     // �ְ� ���� �ؽ�Ʈ (���ڸ� ǥ��)
    [SerializeField] private Text currentScoreText;  // ���� ���� �ؽ�Ʈ (���ڸ� ǥ��)
    [SerializeField] private Text currentGoldText;    // ���� ��� �ؽ�Ʈ (���ڸ� ǥ��)
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GoldText;

    public int score = 0;
    public int gold = 0;
    public int highScore;

    private void Start()
    {

    }

    // ���� �߰�
    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = $"Score : {score}";
    }

    // ��� �߰�
    public void AddGold(int amount)
    {
        gold += amount;
        GoldText.text = $"Gold : {gold}";
    }


    // �ְ� ���� ����
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
            // SaveScore();
        }
    }


    // public void EndingScore()
    // {
    //     //�ְ� ���� �ҷ��ͼ� �ؽ�Ʈ�� ǥ��
    //     int highScore = PlayerPrefs.GetInt("BestScore", 0);
    //     highScoreText.text = highScore.ToString();

    //     //���� ���� �ʱ�ȭ �� �ؽ�Ʈ�� ǥ��
    //     score = 0;
    //     currentScoreText.text = score.ToString();

    // }

}
