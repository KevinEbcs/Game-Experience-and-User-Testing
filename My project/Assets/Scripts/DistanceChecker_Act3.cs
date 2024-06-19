using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceChecker_Act3 : MonoBehaviour
{

    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Crystal;

    [SerializeField] private TextMeshProUGUI text;

    public static bool text_active = false;
    private bool ninth_text_active = false;
    private bool tenth_text_active = false;


    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!ninth_text_active && !text_active)
        {
            text.text = "You find yourself in a scenery. What is happening? What are those crystals?";
            Time.timeScale = 0f; // freeze time
            if (!text_active && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return)))
            {
                text.text = "Bring yourself more clarity, so that you may be whole again, and perhaps then you will recognize your true self. Solve the four riddles in this world to solve the riddle for your inner self.";
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
            {
                text.text = "If you don't, then you will be here forever, as you are now. Unfinished, lost and empty.";
                ninth_text_active = true;
                text_active = true;
            }
        }
        
        if (text_active)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1f; // time resumes
                text.text = "";
                text_active = false;
            }
        }
    }
}