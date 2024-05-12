using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class debugCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private List<string> cameraKeys;

    [SerializeField] private List<Camera> debugCameras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            foreach (var key in cameraKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    if (mainCamera.isActiveAndEnabled)
                    {
                        mainCamera.gameObject.SetActive(false);
                        debugCameras[cameraKeys.BinarySearch(key)].gameObject.SetActive(true);
                    }
                    else
                    {
                        mainCamera.gameObject.SetActive(true);
                        debugCameras[cameraKeys.BinarySearch(key)].gameObject.SetActive(false);
                    }
                    
                }
            }
        }
    }
}
