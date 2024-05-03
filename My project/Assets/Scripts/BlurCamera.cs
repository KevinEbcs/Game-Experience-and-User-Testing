using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blur_Camera : MonoBehaviour
{
    private Material blur;
    private GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        sphere = transform.GetChild(0).GameObject();
        blur = sphere.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            updateBlurIntensity(-0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            updateBlurIntensity(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            updateBlurMultiplier(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            updateBlurMultiplier(-0.1f);
        }
    }

    void updateBlurIntensity(float delta)
    {
        float blurIntens = blur.GetFloat("_Intensity");
        blurIntens += delta;
        Mathf.Clamp(blurIntens, 0, 5);
        blur.SetFloat("_Intensity", blurIntens);
    }
    
    void updateBlurMultiplier(float delta)
    {
        float blurMult = blur.GetFloat("_Multiplier");
        blurMult += delta;
        Mathf.Clamp(blurMult, 0, 5);
        blur.SetFloat("_Multiplier", blurMult);
    }
}
