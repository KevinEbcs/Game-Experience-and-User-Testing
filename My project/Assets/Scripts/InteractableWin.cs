using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableWin : MonoBehaviour
{
    [SerializeField] private SceneAsset nextScene;

    [SerializeField] private LevelLoader _levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.up, 4f, (1 << 18)))
        {
            _levelLoader.LoadNextLevel(nextScene);
        }
    }
}
