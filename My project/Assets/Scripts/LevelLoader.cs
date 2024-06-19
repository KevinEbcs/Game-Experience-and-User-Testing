using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }
    
    public Animator transition;
    public float transitionTime = 1f;

    public GameObject child;
    private Animator childAnim;

    private GameProgress gP;
    
    public void Start()
    {
        childAnim = child.GetComponent<Animator>();
        
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
        Debug.Log("FadeOut");
        transition.SetTrigger("Start");
        //Wait
        //yield return new WaitForSeconds(transitionTime);
        //Load scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadLevel(string levelName)
    {
        //Play animation
        Debug.Log("FadeOut");
        transition.SetTrigger("Start");
        //Wait
        //yield return new WaitForSeconds(transitionTime);
        //Load Scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadNextLevel(string sceneName, int transId = 0)
    {
        if (transId == 0)
        {
            StartCoroutine(LoadLevel(sceneName));
        }
        else
        {
            gP.SetNextLevel(sceneName);
            gP.SetTransText(transId);
            StartCoroutine(LoadLevel("TransitionText"));
        }
        //LoadNextLevel(SceneManager.GetSceneByName(sceneName).buildIndex);
    }
}
