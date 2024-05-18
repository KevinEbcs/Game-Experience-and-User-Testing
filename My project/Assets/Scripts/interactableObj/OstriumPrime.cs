using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OstriumPrime : DynamicObject
{
    private Vector3 startPos;
    private bool rotate = true;
    [SerializeField] private float hoverMagnitude = 0.1f;
    [SerializeField] private float hoverSpeed = 1.5f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float distanceToPlayer = 15.0f;


    [SerializeField] private GameObject player;
    private Vector3 initPlayerPos;
    //private bool _interacted = false;

    void Start()
    {
        InteractText = "E OstriumPrime";
        startPos = player.transform.position;
        startPos.x += distanceToPlayer;

        initPlayerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = startPos.y + Mathf.Cos(Time.time * hoverSpeed) * hoverMagnitude;
        transform.position = pos;

        transform.Rotate(0.0f, Time.time * rotationSpeed, 0.0f);

        if(rotate){
            transform.RotateAround(initPlayerPos, Vector3.up, movementSpeed * Time.deltaTime);
            if((player.transform.position - transform.position).magnitude < 5){
                rotate = false;
            }
        }
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
