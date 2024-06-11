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

    public void LoadNextLevel(int level = -1)
    {
        StartCoroutine(level > -1 ? LoadLevel(level) : LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

   

    IEnumerator LoadLevel(int levelIndex){
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel(String sceneName)
    {
        LoadNextLevel(SceneManager.GetSceneByName(sceneName).buildIndex);
    }
    
    public void LoadNextLevel(SceneAsset sceneAsset)
    {
        StartCoroutine(LoadLevel(sceneAsset));
    }

    IEnumerator LoadLevel(SceneAsset sceneAsset)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        SceneManager.LoadScene(sceneAsset.name);
    }
}
