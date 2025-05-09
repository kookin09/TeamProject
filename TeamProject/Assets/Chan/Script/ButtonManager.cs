using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    Button ExitButton;
    Button RestartButton;
    void Start()
    {
        ExitButton = GameObject.Find("Exit").GetComponent<Button>();
        RestartButton = GameObject.Find("Retry").GetComponent<Button>();

        ExitButton.onClick.AddListener(ExitGame);
        RestartButton.onClick.AddListener(LoadScene);
    }
    public void LoadScene()
    {
        // SceneManager.LoadScene(""); // �ε��� �� �̸�
        Debug.Log("LoadScene");
    }
    public void ExitGame()
    {
       //  SceneManager.LoadScene(""); // �ε��� �� �̸�
       Debug.Log("ExitGame");
       
    }
}
