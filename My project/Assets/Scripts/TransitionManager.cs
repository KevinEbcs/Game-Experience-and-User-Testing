using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    public TextMeshProUGUI testField;
    
    private GameProgress gP;
    private LevelLoader _levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        gP = GameProgress.GetInstance();
        _levelLoader = levelLoader.GetComponent<LevelLoader>();
        writeText(gP.GetTransText());
    }

    void writeText(int textId)
    {
        testField.text = "test " + textId;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            string nextLevel = gP.GetNextLevel();
            int nextLevelId = gP.GetNextLevelId();
            if(nextLevel != "")
                _levelLoader.LoadNextLevel(nextLevel);
            else if(nextLevelId != 0)
                _levelLoader.LoadNextLevel(nextLevelId);
            else
                Debug.LogError("No valid Scene available in TransitionManager!");
        }
    }
}
