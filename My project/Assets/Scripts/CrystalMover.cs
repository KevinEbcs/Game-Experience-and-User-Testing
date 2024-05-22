using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMover : MonoBehaviour
{
    private int listIndex = 0;
    
    [SerializeField] private List<Vector3> crystalPositions;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<CrystalManager>().crystalMoveEvent.AddListener(MoveCrystal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCrystal()
    {
        this.transform.position = crystalPositions[listIndex];
        ++listIndex;
    }
}
