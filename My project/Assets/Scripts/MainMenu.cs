using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    private LevelLoader _levelLoader;

    private void Start()
    {
        _levelLoader = levelLoader.GetComponent<LevelLoader>();
    }

    // Load Scene
    public void Play(){
        Cursor.visible = false;
        if (_levelLoader)
        {
            _levelLoader.LoadNextLevel();
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
