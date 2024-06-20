using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public int LevelsCompleted;

    public Transform Seg1;
    public Transform Seg2;
    public Transform Seg3;
    // Start is called before the first frame update
    void Start()
    {
        LevelsCompleted = FindAnyObjectByType<GameProgress>().NrFinishedLevels();
        Debug.Log("LevelsCompleded: " + LevelsCompleted);
        if(LevelsCompleted<3)
        foreach (Transform child in Seg1)
        {
            child.GetComponent<Renderer>().enabled=false;
            child.GetComponent<Collider>().enabled = false;
            Debug.Log(child.name);
        }
        if(LevelsCompleted<4)
        foreach (Transform child in Seg2)
        {
            child.GetComponent<Renderer>().enabled=false;
            child.GetComponent<Collider>().enabled = false;
        }
        if(LevelsCompleted<5)
        foreach (Transform child in Seg3)
        {
            child.GetComponent<Renderer>().enabled=false;
            child.GetComponent<Collider>().enabled = false;
        }
        
    }
    
}
