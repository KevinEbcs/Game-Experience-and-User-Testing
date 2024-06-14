using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameProgress.GetInstance().finishLevel(1,5);
        GameProgress.GetInstance().finishLevel(2,7);
        GameProgress.GetInstance().finishLevel(3,8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
