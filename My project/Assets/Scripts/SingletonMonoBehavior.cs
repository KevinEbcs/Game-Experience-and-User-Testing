using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    private void Awake()
    {
        timeOfCreation = Time.fixedTime;
        
        
        
        if (instance != null && instance != this)
        {
            Debug.Log($"Es existiert mehr als eine Instanz von {typeof(T).Name}, {timeOfCreation}");
            if (timeOfCreation > oldestTimeOfCreation)
            {
                Debug.Log($"{typeof(T).Name} wird zerstört");
                Destroy(this.GameObject());
                
            }    
        }

        oldestTimeOfCreation = timeOfCreation;

    }
}