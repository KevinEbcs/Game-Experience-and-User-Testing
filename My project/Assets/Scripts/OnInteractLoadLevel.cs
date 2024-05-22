using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OnInteractLoadLevel : DynamicObject
{
    [SerializeField] private LevelLoader _levelLoader;

    [SerializeField] private SceneAsset nextScene;

    // Start is called before the first frame update
    void Start()
    {
        InteractText = "E Load " + nextScene.name;
    }

    public override void ObjectInteract()
    {
        _levelLoader.LoadNextLevel(nextScene);
    }
}
