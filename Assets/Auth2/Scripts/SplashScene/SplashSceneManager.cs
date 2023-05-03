using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadMainMenuScene();
    }

    void LoadMainMenuScene()
    {
        SceneManager.LoadScene(Configuration.StartMenuScene);
    }
}
