using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brille : MonoBehaviour
{
    private GameProgress _gameProgress;
    private float maxFocus;
    private float currentFocus;
    private Blur_Camera blurCamera;
    private float standardBlur = 0f;
    private bool isFirstUpdate = true;
    private CircularProgressBar focusCircle;

    //Liste von maxFocus-Werten(x) und blurriness(y) nach Anzahl abgeschlossener Level (index)
    [SerializeField] private List<Vector2> focusThresholds;
    [SerializeField] private KeyCode interactKeyCode;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Max Focus: {maxFocus}");
        try
        {
            _gameProgress = GameProgress.GetInstance();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        focusCircle = FindAnyObjectByType<CircularProgressBar>();

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

        if (maxFocus == 0)
        {
            
            foreach (var circle in GameObject.FindGameObjectsWithTag("Destroy"))
            {
                //circle.GameObject().SetActive(false);
                Debug.Log("zerstören");
                Destroy(circle);
            }
        }
        Debug.Log(_gameProgress.NrFinishedLevels());

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

        
        if (focusCircle != null && focusCircle.GameObject().activeSelf)
        {
            focusCircle.m_FillAmount = (currentFocus / maxFocus);
        }
    }
}
