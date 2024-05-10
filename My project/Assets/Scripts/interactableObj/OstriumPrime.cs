using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OstriumPrime : DynamicObject
{
    //private bool _interacted = false;
    void Start()
    {
        InteractText = "E OstriumPrime";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ObjectInteract()
    {
        ActionBeforeSceneChange();
        
        SceneManager.LoadScene("Lennart_Test_Scene");
    }

    void ActionBeforeSceneChange()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(10 - i);
            StartCoroutine(Waiter(1));
        }
    }

    IEnumerator Waiter(float time)
    {
        yield return new WaitForSeconds(time);
    }
    
}
