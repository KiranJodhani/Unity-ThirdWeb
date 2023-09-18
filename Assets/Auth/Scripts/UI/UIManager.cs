using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject MainGameUiPanel;
    public GameObject GameOverPanel;
    public Cannon cannonInstance;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    public int CurrentScore;
    public int LastScore;
    public float SessionLength;

    public GameConfiguration gameConfiguration;

    public static UIManager Instance;
    private void Awake()
    {
        if(!Configuration.Instance)
        {
            SceneManager.LoadScene(Configuration.SplashScene);
        }

        Instance = this;
    }
    void Start()
    {
        gameConfiguration = JsonUtility.FromJson<GameConfiguration>(Configuration.Instance.GameConfigurationData.text);
        if (PlayerPrefs.HasKey(Configuration.ScoreKey))
        {
            LastScore = PlayerPrefs.GetInt(Configuration.ScoreKey);
        }

        SessionLength = gameConfiguration.gameScene.SessionLength;
    }

    
    void Update()
    {
        if(SessionLength>0)
        {
            SessionLength -= Time.deltaTime;
            TimerText.text= Mathf.FloorToInt(SessionLength / 60.0f).ToString("0") + ":" + Mathf.FloorToInt(SessionLength % 60.0f).ToString("00");
        }
        else
        {
            cannonInstance.enabled = false;
            GameOverPanel.SetActive(true);
            TimerText.text = "00:00";
            if (CurrentScore>LastScore)
            {
                PlayerPrefs.SetInt(Configuration.ScoreKey, CurrentScore);
                PlayerPrefs.Save();
            }
            
        }
    }

    public void UpdateScore()
    {
        CurrentScore++;
        ScoreText.text = CurrentScore.ToString();
    }

    public void ReplaySameLevel()
    {
        SceneManager.LoadScene(Configuration.GameScene);
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene(Configuration.StartMenuScene);
    }
}
