using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableWin : MonoBehaviour
{
    [SerializeField] private string nextScene;

    [SerializeField] private LevelLoader _levelLoader;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Physics.Raycast(transform.position, Vector3.up, 4f, (1 << 18)))
        {
            GameProgress gameProgress = GameProgress.GetInstance();
            if (gameProgress != null)
            {
                gameProgress.finishLevel(SceneManager.GetActiveScene().buildIndex,time);
            }
            _levelLoader.LoadNextLevel(nextScene);
        }
    }
}
