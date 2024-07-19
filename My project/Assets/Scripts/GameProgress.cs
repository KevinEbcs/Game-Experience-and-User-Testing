using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameProgress : SingletonMonoBehavior<GameProgress>
{
    private List<bool> levelsFinished = new List<bool>();
    private int nrFinishedLevels = 0;
    
    public List<float> times;
    public List<String> skipedLevel;
    public List<int> levelorder;
    public float totaltime;
    public string playername = default;

    public bool worldVisited = false;

    [HideInInspector] public UnityEvent<int> levelFinishedEvent = new UnityEvent<int>();

    private string nextLevel = "";
    private int nextLevelId = 0;
    private int transText = 0;
    private PauseMenu _pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        totaltime = 0;
        DontDestroyOnLoad(this);

        int numberOfScenes = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < numberOfScenes; i++)
        {
            levelsFinished.Add(false);
        }

        
    }

    void Awake()
    {
        base.Awake();
        Debug.Log($"{nrFinishedLevels} have been finished");
        SceneManager.sceneLoaded += SceneLoaded;
    }

    public void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        base.SceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        try
        {
            _pauseMenu = FindAnyObjectByType<PauseMenu>();
            _pauseMenu.mainMenuEvent.AddListener(resetProgress);
        }
        catch (Exception e)
        {
            Debug.Log($"Szene {SceneManager.GetActiveScene().buildIndex}: Kein Pausemenü gefunden");
            //Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        totaltime += Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.F12))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "LevelX" || scene.name == "Puzzle" || scene.name == "Puzzle_stone" || scene.name == "Puzzle_Taste")
            {
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    public void finishLevel(int index, float time)
    {

        if (!levelsFinished[index])
        {
            levelsFinished[index] = true;
            ++nrFinishedLevels;
        }
        levelFinishedEvent.Invoke(index);
        
        Debug.Log($"Finished level {index}");
        
        levelorder.Add(index);
        times.Add(time);
    }

    public bool isLevelFinished(int index)
    {
        return levelsFinished[index];
    }

    public int NrFinishedLevels()
    {
        return nrFinishedLevels;
    }

    public void End()
    {
        string saveFile = Path.Combine(Application.persistentDataPath, playername+".json");
        Debug.Log("Saved in: " + saveFile);
        var json = JsonUtility.ToJson(levelorder.Serialize()) + JsonUtility.ToJson(times.Serialize()) + JsonUtility.ToJson(skipedLevel.Serialize()) + totaltime;
        File.WriteAllText(saveFile, json);
    }

    public void resetProgress()
    {
        Debug.Log("Reset called");
        for (int i = 0; i < levelsFinished.Count; i++)
        {
            levelsFinished[i] = false;
        }
        nrFinishedLevels = 0;
        nextLevel = "";
        nextLevelId = 0;
        transText = 0;
    }
    
    public void SetTransText(int textId)
    {
        transText = textId;
    }

    public void SetNextLevelId(int level)
    {
        nextLevelId = level;
    }
    
    public void SetNextLevel(string levelName)
    {
        nextLevel = levelName;
    }

    public int GetTransText()
    {
        return transText;
    }

    public int GetNextLevelId()
    {
        return nextLevelId;
    }

    public string GetNextLevel()
    {
        return nextLevel;
    }
}
