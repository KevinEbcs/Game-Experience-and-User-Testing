using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SingletonMonoBehavior<T> : MonoBehaviour where T:MonoBehaviour
{
    private static float oldestTimeOfCreation;
    private float timeOfCreation;
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType<T>();
            if (instance == null)
                throw new Exception($"Keine Instanz von {typeof(T).Name} gefunden");
        }
        return instance;
    }

    public void Awake()
    {
        timeOfCreation = Time.fixedTime;
        

        SceneManager.sceneLoaded += SceneLoaded;

        oldestTimeOfCreation = timeOfCreation;

    }

    public void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //Debug.Log($"Es gibt {FindObjectsByType<T>(FindObjectsSortMode.None).Length} Instanzen von {typeof(T).Name}");
        
        if ((instance != null && instance != this) || FindObjectsByType<T>(FindObjectsSortMode.None).Length > 1)
        {
            Debug.Log($"Es existiert mehr als eine Instanz von {typeof(T).Name}, {timeOfCreation}");
            if (timeOfCreation > oldestTimeOfCreation)
            {
                Debug.Log($"{typeof(T).Name} wird zerstört");
                Destroy(this.GameObject());
                
            }    
        }
    }
}