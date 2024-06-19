using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private int xSens;

    [SerializeField] private int ySens;

    [SerializeField] private Transform orientation;

    private float xRotation;

    private float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            OptionsManager optionsManager = OptionsManager.GetInstance();
            xSens = (int)(xSens * optionsManager.sensitivityMultiplier);
            ySens = (int)(ySens * optionsManager.sensitivityMultiplier);
            GetComponent<Camera>().fieldOfView = optionsManager.fieldOfView;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
