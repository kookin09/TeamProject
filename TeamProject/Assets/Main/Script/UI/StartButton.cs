using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        
    }

}
