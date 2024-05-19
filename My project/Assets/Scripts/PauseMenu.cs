using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // to make sure game is running in first frame (it is not paused)
    }

    // Update is called once per frame
    void Update()
    {
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
        Paused = true;
    }

    public void Play(){
        PauseMenuCanvas.SetActive(false); // Pause menu will disappear if esc is pressed
        Time.timeScale = 1f; // time resumes
        Paused = false;
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("Main_Menu");
        // SceneManager.LoadScene(0); // main menu has Build Index 0
    }
}