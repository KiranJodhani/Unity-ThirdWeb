using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{

    public TextMeshProUGUI GameTitle;
    public TextMeshProUGUI GameVersion;
    public TextMeshProUGUI Score;

    public GameConfiguration gameConfiguration;

    private void Awake()
    {
        if(Configuration.Instance==null)
        {
            SceneManager.LoadScene(Configuration.SplashScene);
        }
    }

    void Start()
    {
        gameConfiguration = JsonUtility.FromJson<GameConfiguration>(Configuration.Instance.GameConfigurationData.text);
        GameTitle.text = gameConfiguration.mainScene.GameTitle;
        GameVersion.text = gameConfiguration.mainScene.GameVersion;
        if(PlayerPrefs.HasKey(Configuration.ScoreKey))
        {
            Score.text = PlayerPrefs.GetInt(Configuration.ScoreKey).ToString();

        }
        else
        {
            PlayerPrefs.SetInt(Configuration.ScoreKey, 0);
            Score.text = "0";

        }
    }


    public void OnClickkPlayButton()
    {
        SceneManager.LoadScene(Configuration.GameScene);

    }

   
}
