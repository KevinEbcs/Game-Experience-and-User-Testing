using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Crystal;

    [SerializeField] private TextMeshProUGUI text;

    private bool text_active = false;
    private bool first_text_active = false;
    private bool second_text_active = false;
    private bool third_text_active = false;
    private bool fourth_text_active = false;
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
        float dist = GetDistance(Player, Crystal);
        if (dist < 15 && !first_text_active && !text_active)
        {
            text.text = "You are alone in a place that is empty except for a red crystal ahead of you. It is quiet here.";
            Time.timeScale = 0f; // freeze time
            first_text_active = true;
            text_active = true;
        } else if (dist < 11 && !second_text_active && !text_active && first_text_active && zeit > 2)
        {
            text.text = "A slight vibration begins to resonate through your body. It seems that the crystal is the source of this feeling. Nevertheless, you proceed on your path…";
            Time.timeScale = 0f; // freeze time
            second_text_active = true;
            text_active = true;
            zeit = 0;
        } else if (dist < 7 && !third_text_active && !text_active && second_text_active && zeit > 2)
        {
            text.text = "Your body trembles. You try to grasp what seems to be the source of this new kind of feeling.";
            Time.timeScale = 0f; // freeze time
            third_text_active = true;
            text_active = true;
            zeit = 0;
        } else if (dist < 4 && !fourth_text_active && !text_active && third_text_active && zeit > 2)
        {
            text.text = "Silence as you reach forward. ";
            Time.timeScale = 0f; // freeze time
            fourth_text_active = true;
            text_active = true;
            zeit = 0;
        }

        if (text_active) {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1f; // time resumes
                text.text = "";
                text_active = false;
            }
        }
        
        
    }

    public static float GetDistance(GameObject player, GameObject crystal)
    {
        return Vector3.Distance(player.transform.position, crystal.transform.position);
    }
}
