using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnInteractLoadLevel : DynamicObject
{
    [SerializeField] private LevelLoader _levelLoader;

    [SerializeField] private String nextScene;

    // Start is called before the first frame update
    void Start()
    {
        InteractText = "E Load " + nextScene;
    }

    public override void ObjectInteract()
    {
        _levelLoader.LoadNextLevel(nextScene);
    }
}
