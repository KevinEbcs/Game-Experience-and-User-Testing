using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceChecker_Act3 : MonoBehaviour
{

    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Crystal;

    [SerializeField] private TextMeshProUGUI text;
    
    [SerializeField] private GameObject continuePanel;

    public static bool text_active = false;
    private bool ninth_text_active = false;
    private bool ninth2_text_active = false;
    private bool tenth_text_active = false;

    private float zeit;


    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        zeit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        zeit += Time.deltaTime;
        if (!ninth_text_active && !text_active && zeit > 2)
        {
            text.text = "You find yourself in a scenery. What is happening? What are those crystals?";
            Time.timeScale = 0f; // freeze time
            ninth_text_active = true;
            text_active = true;
        }
        else if (!ninth2_text_active && !text_active && ninth_text_active)
        {
            text.text = "Bring yourself more clarity, so that you may be whole again, and perhaps then you will recognize your true self. Solve three of the four riddles in this world to solve the riddle for your inner self.";
            Time.timeScale = 0f; // freeze time
            ninth2_text_active = true;
            text_active = true;
        }

        else if (!tenth_text_active && !text_active && ninth2_text_active)
        {
            text.text = "If you don't, then you will be here forever, as you are now. Unfinished, lost and empty.";
            Time.timeScale = 0f; // freeze time
            tenth_text_active = true;
            text_active = true;
        }
        
        if (text_active)
        {
            continuePanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
            {
                continuePanel.SetActive(false);
                Time.timeScale = 1f; // time resumes
                text.text = "";
                text_active = false;
            }
        }
    }
}