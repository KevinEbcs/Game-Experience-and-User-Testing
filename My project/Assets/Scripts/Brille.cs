using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brille : MonoBehaviour
{
    private GameProgress _gameProgress;
    private float maxFocus;
    private float currentFocus;
    private Blur_Camera blurCamera;
    private float standardBlur = 0f;
    private bool isFirstUpdate = true;

    //Liste von maxFocus-Werten(x) und blurriness(y) nach Anzahl abgeschlossener Level (index)
    [SerializeField] private List<Vector2> focusThresholds;
    [SerializeField] private KeyCode interactKeyCode;

    // Start is called before the first frame update
    void Start()
    { 
        _gameProgress = GameProgress.GetInstance();
        
        blurCamera = FindAnyObjectByType<Blur_Camera>();


        if (_gameProgress != null)
        {
            maxFocus = focusThresholds[_gameProgress.NrFinishedLevels()].x;
            currentFocus = maxFocus;
        }
        else
        {
            maxFocus = 0f;
            currentFocus = 0f;
        }
        
    }

    // Update is called once per frame

    private void Update()
    {
        if (isFirstUpdate)
        {
            standardBlur = blurCamera.GetBlurIntensity();
            Debug.Log("standard blur = " + standardBlur);
            isFirstUpdate = false;
        }
        
        if (Input.GetKey(interactKeyCode) && currentFocus > 0.05)
        {
            if(Input.GetKeyDown(interactKeyCode))
            {
                blurCamera.UpdateBlurIntensity(focusThresholds[_gameProgress.NrFinishedLevels()].y - standardBlur);
                Debug.Log("Blur Reduced to" + focusThresholds[_gameProgress.NrFinishedLevels()].y);
            }

            currentFocus -= Time.deltaTime;
        }
        
        if (currentFocus < 0.05 || Input.GetKeyUp(interactKeyCode))
        {
            if (_gameProgress != null) 
                blurCamera.UpdateBlurIntensity(standardBlur - focusThresholds[_gameProgress.NrFinishedLevels()].y);
            //Debug.Log("Blur increased to standard");
        }

        if (!Input.GetKey(interactKeyCode) && currentFocus < maxFocus)
        {
            currentFocus += Time.deltaTime * 2;
            currentFocus = Mathf.Clamp(currentFocus, 0, maxFocus);
        }
    }
}
