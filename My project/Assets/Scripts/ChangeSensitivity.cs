using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeSensitivity : MonoBehaviour
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

    public void ModifySensitivity(Single newSense)
    {
        if (_optionsManager != null)
        {
            _optionsManager.changeSensitivity((int)newSense);
        }
    }
}
