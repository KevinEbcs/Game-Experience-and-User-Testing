using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceChecker_Act2 : MonoBehaviour
{

    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Crystal;

    [SerializeField] private TextMeshProUGUI text;
    
    [SerializeField] private GameObject continuePanel;

    private bool text_active = false;
    private bool fifth_text_active = false;
    private bool fifth2_text_active = false;
    private bool sixth_text_active = false;
    private bool seventh_text_active = false;
    private bool eighth_text_active = false;

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
        if (!fifth_text_active && !text_active && zeit > 2)
        {
            text.text = "You feel the ground beneath your feet. It gives you balance and stability in the darkness that surrounds you.";
            Time.timeScale = 0f; // freeze time
            fifth_text_active = true;
            text_active = true;
        }

        else if (!fifth2_text_active && fifth_text_active && !text_active) 
        {
            text.text = "But then you hear something. Unexpectedly, it resonates in your head. You have never heard such pleasant music before. You set off to follow the magical sound…";
            fifth2_text_active = true;
            text_active = true;
        } else if (!sixth_text_active && !text_active && fifth2_text_active && Vector3.Distance(Crystal.transform.position, new Vector3(-1.16999996f,2.1400001f,11.3500004f)) < 1)
        {
            text.text = "Enchanted by the sounds, you creep deeper into the maze.";
            Time.timeScale = 0f; // freeze time
            sixth_text_active = true;
            text_active = true;
        } else if (!seventh_text_active && !text_active && sixth_text_active && Vector3.Distance(Crystal.transform.position, new Vector3(13.2299995f,1.13999999f,8.18000031f)) < 1 && DistanceChecker.GetDistance(Player, Crystal) < 8)
        {
            text.text = "It seems as if the crystal has appeared again.";
            Time.timeScale = 0f; // freeze time
            seventh_text_active = true;
            text_active = true;
        } else if (!eighth_text_active && !text_active && seventh_text_active && Vector3.Distance(Crystal.transform.position, new Vector3(13.2299995f,1.13999999f,8.18000031f)) < 1 && DistanceChecker.GetDistance(Player, Crystal) < 4)
        {
            text.text = "You stretch out your hand to reach it. This time, an unstoppable force gently enters your head. The music surrounds you entirely. Making you feel light and calm.";
            Time.timeScale = 0f; // freeze time
            eighth_text_active = true;
            text_active = true;
        } 

        if (text_active) {
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