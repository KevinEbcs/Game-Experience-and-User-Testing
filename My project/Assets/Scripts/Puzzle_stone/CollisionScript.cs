using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public GameObject collider_box;
    public TriggerManager triggerManager;
    
    void Update(){
        StartCoroutine(triggerCheck());
    }


    IEnumerator triggerCheck(){
        if (triggerManager.activeTriggers == 9){ // change to 3 for testing
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Overworld");
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
