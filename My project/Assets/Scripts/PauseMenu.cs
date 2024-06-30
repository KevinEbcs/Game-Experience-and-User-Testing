using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    [SerializeField] private GameObject SkipPanel;
    [SerializeField] private TMP_InputField SkipCode;
    [SerializeField] private String code = "skipPlease";
    private float timer;

    public GameObject levelLoader;
    private LevelLoader _levelLoader;

    [HideInInspector] public UnityEvent mainMenuEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        Time.timeScale = 1f; // to make sure game is running in first frame (it is not paused)
        _levelLoader = levelLoader.GetComponent<LevelLoader>();
        // Add a listener to be called when a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Paused){
                Play();
            } else {
                Stop();
            }
        }
    }

    void Stop(){
        PauseMenuCanvas.SetActive(true); // Pause menu will appear if esc is pressed
        Time.timeScale = 0f; // freeze time
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Paused = true;
    }

    public void Play(){
        SkipPanel.SetActive(false);
        PauseMenuCanvas.SetActive(false); // Pause menu will disappear if esc is pressed
        Time.timeScale = 1f; // time resumes
        if (SceneManager.GetActiveScene().name == "Puzzle_stone"){
            Cursor.visible = true;
        } else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        Paused = false;
    }

    public void MainMenuButton(){// SceneManager.LoadScene("Main_Menu");
        SkipPanel.SetActive(false);
        mainMenuEvent.Invoke();
        //Debug.Log("Reset: Menu");
        _levelLoader.LoadNextLevel(0);
        //ceneManager.LoadScene(0); // main menu has Build Index 0
    }

    public void Skip()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LevelX" || scene.name == "Puzzle" || scene.name == "Puzzle_stone" || scene.name == "Puzzle_Taste")
        {
            SkipPanel.SetActive(true);
        }
    }

    public void VerifiedSkip()
    {
        if (SkipCode.text == "skipPlease")
        {
            SkipPanel.SetActive(false);
            GameProgress.GetInstance().skipedLevel.Add(SceneManager.GetActiveScene().name);
            GameProgress.GetInstance().finishLevel(SceneManager.GetActiveScene().buildIndex,timer);
            _levelLoader = FindAnyObjectByType<LevelLoader>();
            _levelLoader.LoadNextLevel("Overworld");
        }
        if (SkipCode.text == "justSkip")
        {
            SkipPanel.SetActive(false);
            _levelLoader.LoadNextLevel("Overworld");
        }
    }
    
}