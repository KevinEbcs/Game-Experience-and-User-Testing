using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [HideInInspector] public UnityEvent playerTrigger = new UnityEvent();
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    {
       
        playerTrigger.Invoke();
        GetComponent<Collider>().enabled = false;

        Debug.Log("Trigger");
    }
}
