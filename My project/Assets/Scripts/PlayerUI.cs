using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private CanvasGroup playerInteract;
    // Start is called before the first frame update
    void Start()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            switch (transform.GetChild(i).name)
            {
                case "Interact":
                    playerInteract = transform.GetChild(i).transform.GameObject().GetComponent<CanvasGroup>();
                    break;
                default:
                    Debug.Log($"UI element could not be registered: {transform.GetChild(i).name}");
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideInteract(bool show)
    {
        if (show)
        {
            playerInteract.alpha = 1;
        }
        else
        {
            playerInteract.alpha = 0;   
        }
    }
}
