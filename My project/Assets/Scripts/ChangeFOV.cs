using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFOV : MonoBehaviour
{
    private OptionsManager _optionsManager;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            _optionsManager = OptionsManager.GetInstance();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyFOV(Single newFOV)
    {
        if (_optionsManager != null)
        {
            _optionsManager.changeFOV((int)newFOV);
        }
    }
}
