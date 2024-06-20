using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : SingletonMonoBehavior<OptionsManager>
{
    [HideInInspector] public float sensitivityMultiplier{ get; set;}

    [HideInInspector] public int fieldOfView { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
