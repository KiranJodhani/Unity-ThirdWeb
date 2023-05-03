using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    [Header("Game Session Info")]
    [SerializeField] private GameSession _gameSession = null;
    [SerializeField] private Text _scoreValue = null;
    [SerializeField] private GameObject _timeRemaining = null;
    [SerializeField] private Text _timeRemainingValue = null;
    [Header("Game Over")]
    [SerializeField] private GameObject _gameOverScreen = null;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameSession.OnSessionEnd += HandleSessionEnded;
    }

    string GetFormattedTimeFromSeconds( float seconds )
    {
        return Mathf.FloorToInt( seconds / 60.0f ).ToString("0") + ":" + Mathf.FloorToInt( seconds % 60.0f ).ToString("00");
    }

    void HandleSessionEnded()
    {
        _gameSession.OnSessionEnd -= HandleSessionEnded;
        _timeRemaining.SetActive(false);
        _gameOverScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        _timeRemainingValue.text = GetFormattedTimeFromSeconds(_gameSession.timeLeft);
    }
}
