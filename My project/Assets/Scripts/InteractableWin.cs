using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.up, 4f, (1 << 18)))
        {
            Debug.Log("Victory!");
        }
    }
}
