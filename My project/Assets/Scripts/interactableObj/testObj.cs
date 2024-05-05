using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As an interactable objects, this is a child oh DynamicObject. For more specifics check parent class.
public class testObj : DynamicObject
{
    // Start is called before the first frame update
    void Start()
    {
        InteractText = "E Test";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ObjectInteract()
    {
        Debug.Log("test interacted");
    }
}
