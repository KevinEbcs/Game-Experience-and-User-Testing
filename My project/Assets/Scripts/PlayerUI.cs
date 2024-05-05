using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// This class implements everything needed for dynamic parts of the Player UI
public class PlayerUI : MonoBehaviour
{
    // dynamic UI parts
    //  UI part 'Interact': interactText can be changed and playerInteractCanvas can be hidden
    public GameObject interact;
    private CanvasGroup playerInteractCanvas;
    private TextMeshProUGUI interactText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!interact)
        {
            Debug.Log("No interact ui registered for PlayerUI");
        }
        playerInteractCanvas = interact.GetComponent<CanvasGroup>();
        interactText = interact.GetComponent<TextMeshProUGUI>();
    }

    // This function allows us to display or hide the 'interact' text in the UI
    public void ShowHideInteract(bool show)
    {
        if (!playerInteractCanvas)
        {
            Debug.Log("InteractCanvas could not be shown: " +interact.name);
        }
        if (show)
        {
            playerInteractCanvas.alpha = 1;
        }
        else
        {
            playerInteractCanvas.alpha = 0;   
        }
    }

    // This function allows us to set the interactText displayed to the player.
    public void SetInteractText(string text)
    {
        if (interactText)
        {
            interactText.SetText(text);
        }
        else
        {
            Debug.Log("Interact Text could not be set:" +interact.name);
        }
    }
}
