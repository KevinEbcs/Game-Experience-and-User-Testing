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
    public List<int> levelorder;
    public float totaltime;
    public string playername = default;

    [HideInInspector] public UnityEvent<int> levelFinishedEvent = new UnityEvent<int>();

    private string nextLevel = "";
    private int nextLevelId = 0;
    private int transText = 0;

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
        Debug.Log($"{nrFinishedLevels} have been finished");
    }

    // Update is called once per frame
    void Update()
    {
        totaltime += Time.deltaTime;
        
    }

    public void finishLevel(int index, float time)
    {
        levelsFinished[index] = true;
        ++nrFinishedLevels;
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
        var json = JsonUtility.ToJson(levelorder.Serialize()) + JsonUtility.ToJson(times.Serialize()) + totaltime;
        File.WriteAllText(saveFile, json);
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
