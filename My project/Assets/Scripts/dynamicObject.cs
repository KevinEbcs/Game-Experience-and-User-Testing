using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This is the parent class for all interactable objects. Here all functions that are needed for such an objected are implemented.
// Nonetheless those should be overridden in the actual object itself.
public class DynamicObject : MonoBehaviour
{
    // This var contains the text, that is displayed if an object can be interacted with. It is overridden in the start
    // function of all children.
    protected string InteractText = "E to interact";
    private bool _interacted = false;
    
    // This function contains whatever is supposed to happen once the player interacts with an interactable object.
    public virtual void ObjectInteract()
    {
        if (!_interacted)
        {
            _interacted = true;
            Debug.Log("interacted");
            _interacted = false;
        }
    }

    // Returns the InteractText
    public string GetInteractText()
    {
        return InteractText;
    }
}
