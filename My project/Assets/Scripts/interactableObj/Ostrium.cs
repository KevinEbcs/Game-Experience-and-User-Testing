using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// As an interactable objects, this is a child oh DynamicObject. For more specifics check parent class.
public class Ostrium : DynamicObject
{
    private bool _interacted = false;
    private Blur_Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        InteractText = "E Ostrium";
        playerCamera = GameObject.Find("Main Camera").GetComponent<Blur_Camera>();
    }
    
    public override void ObjectInteract()
    {
        if (!_interacted)
        {
            if (playerCamera)
            {
                playerCamera.UpdateBlurIntensity(-1);
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
