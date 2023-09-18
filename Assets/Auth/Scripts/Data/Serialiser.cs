using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Serialiser : MonoBehaviour
{
    public GameConfiguration gameConfiguration;

    private void Start()
    {
        //print(JsonUtility.ToJson(gameConfiguration));
    }
}


[Serializable]
public class GameConfiguration
{
    public MenuScene mainScene;
    public GameScene gameScene;
}

[Serializable]
public class MenuScene
{
    public string GameTitle;
    public string GameVersion;
}

[Serializable]
public class GameScene
{
    public float SessionLength;
}
