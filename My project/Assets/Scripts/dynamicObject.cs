using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dynamicObject : MonoBehaviour
{
    private bool interacting = false;
    public virtual void ObjectInteract()
    {
        if (!interacting)
        {
            interacting = true;
            Debug.Log("interacted");
            interacting = false;
        }
    }
}
