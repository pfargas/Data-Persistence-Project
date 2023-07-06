using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class MainUIHandler : MonoBehaviour
{
    public InputField inputName;
    public TextMeshProUGUI scoreText;

    public MainManager mainManager;
    // Start is called before the first frame update
    void Start()
    {
        if (GeneralManager.Instance != null)
        {
            scoreText.text = "Best Score : " + GeneralManager.Instance.hsName + " : " + GeneralManager.Instance.highscore;
            inputName.text = GeneralManager.Instance.inputName;
        }
    }

    public void StartNew()
    {
        SavePlayerName();
        SceneManager.LoadScene(1);
    }

    private void StartGame()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        mainManager.StartPlay();
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
        GeneralManager.Instance.SaveHighscore(GeneralManager.Instance.m_Points); 
    }

    public void SavePlayerName()
    {
        GeneralManager.Instance.inputName = inputName.text.ToString();
        GeneralManager.Instance.SaveHighscore(0);
    }
}
