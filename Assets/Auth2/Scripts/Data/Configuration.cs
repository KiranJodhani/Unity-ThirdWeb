using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;

public class Configuration : MonoBehaviour
{
    public static Configuration Instance;
    public static readonly string SplashScene = "0_SplashScene";
    public static readonly string StartMenuScene = "1_StartMenuScene";
    public static readonly string GameScene = "2_GameScene";
    public static readonly string ScoreKey = "ScoreKey";

    public TextAsset GameConfigurationData;

    private void Awake()
    {
        Instance = this;
    }

}




