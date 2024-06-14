using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameProgress : SingletonMonoBehavior<GameProgress>
{
    private List<bool> levelsFinished = new List<bool>();
    private int nrFinishedLevels;
    
    public List<float> times;
    public List<int> levelorder;
    public float totaltime;
    public string playername = default;

    [HideInInspector] public UnityEvent<int> levelFinishedEvent = new UnityEvent<int>();

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
        string saveFile = Path.Combine(Application.persistentDataPath, playername,".json");
        levelorder.Serialize();
        times.Serialize();
        totaltime.Serialize();
        var json = JsonUtility.ToJson(levelorder) + JsonUtility.ToJson(times) + totaltime;
        File.WriteAllText(saveFile, json);
    }
}
