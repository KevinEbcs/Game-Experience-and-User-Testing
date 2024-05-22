using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public GameObject collider_box;
    public TriggerManager triggerManager;
    

    void Update(){
        if (triggerManager.activeTriggers == 9){
            Debug.Log("THE PUZZLE IS SOLVED!");
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == collider_box.name){
            triggerManager.activeTriggers += 1;
            Debug.Log("Triggers active: " + triggerManager.activeTriggers);
        }
    }


    void OnTriggerExit(Collider other){
        if (other.gameObject.name == collider_box.name){
            triggerManager.activeTriggers -= 1;
            Debug.Log("Triggers active: " + triggerManager.activeTriggers);
        }
    }
}
