using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameProgress : SingletonMonoBehavior<GameProgress>
{
    private List<bool> levelsFinished = new List<bool>();
    private int nrFinishedLevels;

    [HideInInspector] public UnityEvent<int> levelFinishedEvent = new UnityEvent<int>();

    // Start is called before the first frame update
    void Start()
    {
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
        
    }

    public void finishLevel(int index)
    {
        levelsFinished[index] = true;
        ++nrFinishedLevels;
        levelFinishedEvent.Invoke(index);
    }

    public bool isLevelFinished(int index)
    {
        return levelsFinished[index];
    }

    public int NrFinishedLevels()
    {
        return nrFinishedLevels;
    }
}
