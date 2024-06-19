using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Act3_Progress_Check : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private GameProgress gameProgress;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gameProgress = GameProgress.GetInstance();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameProgress.NrFinishedLevels() == 1 && DistanceChecker_Act3.text_active == false)
        {
            text.text = "Use Q to strengthen your focus.";
            Time.timeScale = 0f; // freeze time
            DistanceChecker_Act3.text_active = true;
        }
        
        if (DistanceChecker_Act3.text_active)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1f; // time resumes
                text.text = "";
                DistanceChecker_Act3.text_active = false;
            }
        }
    }
}
