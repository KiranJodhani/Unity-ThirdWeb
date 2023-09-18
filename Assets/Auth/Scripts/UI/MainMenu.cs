using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _highScore = null;
    // Start is called before the first frame update
    void Start()
    {
        _highScore.text = PlayerPrefs.HasKey("highScore") ? PlayerPrefs.GetInt("highScore").ToString() : 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
