using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public GameObject collider_box;
    public TriggerManager triggerManager;

    private float zeit;

    void Start()
    {
        zeit = 0;
    }

    void Update(){
        StartCoroutine(triggerCheck());
        zeit += Time.deltaTime;
    }


    IEnumerator triggerCheck(){
        if (triggerManager.activeTriggers == 9){ // change to 3 for testing
            GameProgress.GetInstance().finishLevel(SceneManager.GetActiveScene().buildIndex, zeit);
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
