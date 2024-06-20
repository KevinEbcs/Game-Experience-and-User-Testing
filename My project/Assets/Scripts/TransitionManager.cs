using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject levelLoader;
    public TextMeshProUGUI testField;

    [SerializeField] private string[] transTexts;
    
    private GameProgress _gP;
    private LevelLoader _levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        _gP = GameProgress.GetInstance();
        _levelLoader = levelLoader.GetComponent<LevelLoader>();
        WriteText(_gP.GetTransText());
    }

    void WriteText(int textId)
    {
        testField.text = transTexts[textId - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            string nextLevel = _gP.GetNextLevel();
            int nextLevelId = _gP.GetNextLevelId();
            if(nextLevel != "")
                _levelLoader.LoadNextLevel(nextLevel);
            else if(nextLevelId != 0)
                _levelLoader.LoadNextLevel(nextLevelId);
            else
                Debug.LogError("No valid Scene available in TransitionManager!");
        }
    }
}
