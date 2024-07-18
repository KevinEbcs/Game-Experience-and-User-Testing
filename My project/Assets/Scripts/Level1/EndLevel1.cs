using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel1 : MonoBehaviour
{
    //[SerializeField] private SceneAsset nextScene;

    [SerializeField] public LevelLoader _levelLoader;
    private SevenSegment sevenSegment;

    private float time;

    private void Start()
    {
        _levelLoader = FindAnyObjectByType<LevelLoader>();
        sevenSegment = FindAnyObjectByType<SevenSegment>();
        time = 0;
        
        switch (sevenSegment.number)
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
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            int id=SceneManager.GetActiveScene().buildIndex;
            GameProgress.GetInstance().finishLevel(id,time);
            _levelLoader.LoadNextLevel("Overworld");
            Debug.Log("Ende");
        }
        
    }
}
