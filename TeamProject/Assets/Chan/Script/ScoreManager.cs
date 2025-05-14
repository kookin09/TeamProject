using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text highScoreText;     // �ְ� ���� �ؽ�Ʈ (���ڸ� ǥ��)
    public Text currentScoreText;  // ���� ���� �ؽ�Ʈ (���ڸ� ǥ��)

    private int score = 0;

    private void Start()
    {
        // �ְ� ���� �ҷ��ͼ� �ؽ�Ʈ�� ǥ��
        int highScore = PlayerPrefs.GetInt("BestScore", 0);
        highScoreText.text = highScore.ToString();

        // ���� ���� �ʱ�ȭ �� �ؽ�Ʈ�� ǥ��
        score = 0;
        currentScoreText.text = score.ToString();
    }

    // ���� �߰�
    public void AddScore(int amount)
    {
        score += amount;
        currentScoreText.text = score.ToString();
    }

    // �ְ� ���� ����
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

    // ���� �ʱ�ȭ
    public void ResetScore()
    {
        score = 0;
        currentScoreText.text = score.ToString();
    }

    // ���� ���� ��ȯ
    public int GetScore()
    {
        return score;
    }

    private void Update() // �׽�Ʈ��
    {
        // �����̽��� ������ ���� 1�� �߰�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(1);
        }

        // S Ű�� �ְ� ���� ���� �׽�Ʈ
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveScore();
        }
    }
}
