using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [HideInInspector] public UnityEvent playerTrigger = new UnityEvent();
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
  
    public void OnTriggerEnter(Collider other)
    {
        playerTrigger.Invoke();
        GetComponent<Collider>().enabled = false;

        Debug.Log("Trigger");
    }
}
