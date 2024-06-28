using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    private LevelLoader _levelLoader;

    [SerializeField] private TMP_InputField code;

    private void Start()
    {
        _levelLoader = levelLoader.GetComponent<LevelLoader>();
    }

    // Load Scene
    public void Play(){
        Cursor.visible = false;
        if (_levelLoader && code.text != "")
        {
            //Debug.Log("test");
            GameProgress.GetInstance().playername = code.text;
            _levelLoader.LoadNextLevel("Act1");
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // add scenes in build settings and they get an index (order is important!)
        // SceneManager.LoadScene("Game Scene");
    }

    // Quit Game
    public void Quit(){
        Application.Quit();
        Debug.Log("Player has quit the game.");
    }
}
