using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As an interactable objects, this is a child oh DynamicObject. For more specifics check parent class.
public class Ostrium : DynamicObject
{
    public GameObject playerCamera;

    private Blur_Camera cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        InteractText = "E Ostrium";
        if (!playerCamera)
        {
            Debug.LogError("No playCamera provided!");
        }
        else
        {
            cameraScript = playerCamera.GetComponent<Blur_Camera>();   
        }
    }
    
    public override void ObjectInteract()
    {
        if (!_interacted)
        {
            if (cameraScript)
            {
                cameraScript.UpdateBlurIntensity(-1);
                _interacted = true;
            }
            else
            {
                Debug.Log("Could not find Camera Blur Script in: " +transform.name);
            }
        }
        Debug.Log("Ostrium");
    }
}
