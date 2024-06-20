using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : SingletonMonoBehavior<OptionsManager>
{
    /*[HideInInspector]*/
    public float sensitivityMultiplier;

    /*[HideInInspector]*/
    public int fieldOfView;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeFOV(int newFOV)
    {
        fieldOfView = (int)newFOV;
    }

    public void changeSensitivity(int newSense)
    {
        sensitivityMultiplier = (((float)newSense)/(100/1.9f)) + 0.1f;
    }
}
