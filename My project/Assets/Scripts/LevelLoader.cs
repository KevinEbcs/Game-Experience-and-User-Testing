using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public GameProgress gP;

    public void Start()
    {
        gP = GameProgress.GetInstance();
    }

    public void LoadNextLevel(int level = -1, int transId = 0)
    {
        if(transId == 0)
            StartCoroutine(level > -1 ? LoadLevel(level) : LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        else
        {
            gP.SetNextLevelId(level);
            gP.SetTransText(transId);
            StartCoroutine(LoadLevel("TransitionText"));
        }
    }
    
    IEnumerator LoadLevel(int levelIndex){
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string levelName)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel(String sceneName, int transId = 0)
    {
        if(transId == 0)
            StartCoroutine(LoadLevel(sceneName));
        else
        {
            gP.SetNextLevel(sceneName);
            gP.SetTransText(transId);
            StartCoroutine(LoadLevel("TransitionText"));
        }
        //LoadNextLevel(SceneManager.GetSceneByName(sceneName).buildIndex);
    }
}
