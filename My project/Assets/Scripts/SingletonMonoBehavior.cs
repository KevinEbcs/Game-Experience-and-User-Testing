using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehavior<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType<T>();
            if (instance == null)
                throw new Exception("Keine Murmel :(");
        }
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
            throw new Exception($"More than 1 Murmel");
    }
}