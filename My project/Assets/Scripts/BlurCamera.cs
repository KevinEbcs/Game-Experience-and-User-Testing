using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blur_Camera : MonoBehaviour
{
    // Defines the range at which the player is allowed to interact with objects.
    public float interactDistance = 1.8f;
    
    // Components concerning the blurriness of the camera.
    private Material blur;
    private GameObject sphere;
    // Stores the player UI
    private PlayerUI playerUI;
    
    // Start is called before the first frame update
    void Start()
    {
        sphere = transform.GetChild(0).GameObject();
        blur = sphere.GetComponent<Renderer>().material;

        playerUI = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Just for testing and potentially debugging purposes, should get removed later.
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            UpdateBlurIntensity(-1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            UpdateBlurIntensity(1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            UpdateBlurMultiplier(1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            UpdateBlurMultiplier(-1f);
        }

        InteractableObj();
    }

    // Changes the blu intensity depending on delta.
    public void UpdateBlurIntensity(float delta)
    {
        float blurIntens = blur.GetFloat("_Intensity");
        blurIntens += delta;
        blurIntens = Mathf.Clamp(blurIntens, 0, 5);
        blur.SetFloat("_Intensity", blurIntens);
    }
    
    // Changes the blur multiplier depending on delta.
    public void UpdateBlurMultiplier(float delta)
    {
        float blurMult = blur.GetFloat("_Multiplier");
        blurMult += delta;
        blurMult = Mathf.Clamp(blurMult, 0, 5);
        blur.SetFloat("_Multiplier", blurMult);
    }

    // Recognizes an interactable object in range, that the player is looking at.
    void InteractableObj()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactDistance))
        {
            var dynamObj = hit.transform.GameObject().GetComponent<DynamicObject>();
            if (dynamObj)
            {
                playerUI.SetInteractText(dynamObj.GetInteractText());
                playerUI.ShowHideInteract(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dynamObj.ObjectInteract();
                }
            }
            else
            {
                playerUI.ShowHideInteract(false);
            }
        }
        else
        {
            playerUI.ShowHideInteract(false);
        }
    }
}
