using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blur_Camera : MonoBehaviour
{
    // Defines the range at which the player is allowed to interact with objects.
    public float interactDistance = 1.8f;
    // Stores the player UI
    public PlayerUI playerUI;

    //[SerializeField] private GameObject audioObj;
    //private SoundController soundCtrl;
    
    // Components concerning the blurriness of the camera.
    private Material blurMaterial;
    private GameObject blurObject;
    

    //private AudioSource audioSrc;
    //private bool audioPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {
        blurObject = transform.GetChild(0).GameObject();
        blurMaterial = blurObject.GetComponent<Renderer>().material;

        UpdateBlurIntensity(5);

        /*audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
        {
            Debug.LogError("An audio source is missing in " + transform.GameObject().name);
        }

        soundCtrl = audioObj.GetComponent<SoundController>();
        if (soundCtrl == null)
        {
            Debug.LogError("SoundController could not be found in " + transform.GameObject().name);
        }*/

        //playerUI = GameObject.Find("PlayerUI").GetComponent<PlayerUI>();
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
        float blurIntens = blurMaterial.GetFloat("_Intensity");
        blurIntens += delta;
        blurIntens = Mathf.Clamp(blurIntens, 0, 5);
        blurMaterial.SetFloat("_Intensity", blurIntens);
    }
    
    // Changes the blur multiplier depending on delta.
    public void UpdateBlurMultiplier(float delta)
    {
        float blurMult = blurMaterial.GetFloat("_Multiplier");
        blurMult += delta;
        blurMult = Mathf.Clamp(blurMult, 0, 5);
        blurMaterial.SetFloat("_Multiplier", blurMult);
    }

    public float GetBlurIntensity()
    {
        return blurMaterial.GetFloat("_Intensity");
    }

    // Recognizes an interactable object in range, that the player is looking at.
    void InteractableObj()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactDistance))
        {
            //var dynamObj = hit.transform.GameObject().GetComponent<DynamicObject>();
            var dynamObj = GetDynamicObject(hit.transform.GameObject());
            if (dynamObj)
            {
                playerUI.SetInteractText(dynamObj.GetInteractText());
                if(dynamObj.GetShowText())
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

    // Delivers the dynamicObject script if available, even in an object groupe
    DynamicObject GetDynamicObject(GameObject obj)
    {
        var returnObj = obj.GetComponent<DynamicObject>();
        if (returnObj)
        {
            return returnObj;
        }
        else
        {
            if (obj.transform.parent.GameObject())
            {
                return GetDynamicObject(obj.transform.parent.GameObject());
            }
        }

        return returnObj;
    }
    
    
    
}
