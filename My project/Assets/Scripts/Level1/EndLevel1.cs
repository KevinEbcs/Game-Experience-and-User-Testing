using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel1 : MonoBehaviour
{
    [SerializeField] private SceneAsset nextScene;

    [SerializeField] private LevelLoader _levelLoader;
    public SegmentTrigger trigger;

    private void Start()
    {
        trigger = FindAnyObjectByType<SegmentTrigger>();
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (trigger.number)
        {
            case 1:
                GameObject.Find("Cube1").tag="Finish";
                break;
            case 2:
                GameObject.Find("Cube2").tag="Finish";
                break;
            case 3:
                GameObject.Find("Cube3").tag="Finish";
                break;
            case 4:
                GameObject.Find("Cube4").tag="Finish";
                break;
            case 5:
                GameObject.Find("Cube5").tag="Finish";
                break;
            default:
                break;
        }
        if (other.CompareTag("Finish"))
        {
            _levelLoader.LoadNextLevel(nextScene);
        }
        
    }
}