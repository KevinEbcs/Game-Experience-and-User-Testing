using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMover : DynamicObject
{
    private int listIndex = 0;
    
    [SerializeField] private LevelLoader _levelLoader;
    
    [SerializeField] private List<Vector3> crystalPositions;
    
    // Start is called before the first frame update
    void Start()
    {
        InteractText = "E Ostrium Prime";
        GetComponentInParent<CrystalManager>().crystalMoveEvent.AddListener(MoveCrystal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ObjectInteract()
    {
        _levelLoader.LoadNextLevel("Overworld", 2);
    }

    public void MoveCrystal()
    {
        this.transform.position = crystalPositions[listIndex];
        ++listIndex;
        //GetComponent<Rigidbody>().A
    }
}
