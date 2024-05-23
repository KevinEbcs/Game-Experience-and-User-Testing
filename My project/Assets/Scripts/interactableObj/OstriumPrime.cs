using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OstriumPrime : DynamicObject
{
    // Values that can and should be ajusted from the inspector
    [SerializeField] private float hoverMagnitude = 0.1f;
    [SerializeField] private float hoverSpeed = 1.5f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float distanceToPlayer = 15.0f;
    [SerializeField] private Vector3[] wayPoints;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject levelLoader;

    // Values used in the inner workings of this class
    private Vector3 initPlayerPos;
    private Vector3 startPos;
    private int nextwayPoint = 0;
    private LevelLoader _levelLoader;

    // Flags
    private bool rotate = true;
    private bool goToNext = false;
    private bool interact = false;
    

    void Start()
    {
        InteractText = "E OstriumPrime";

        // Set the initial position for this object + a given distance to the player
        startPos = player.transform.position;
        startPos.x += distanceToPlayer;
        
        // Store the initial player position
        initPlayerPos = player.transform.position;

        _levelLoader = levelLoader.GetComponent<LevelLoader>();
        
        if(wayPoints != null || wayPoints.Length != 0){
            Debug.LogError("Please provide way Points for " + transform.GameObject().name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hover and rotation effect of this object
        
        Vector3 pos = transform.position;
        pos.y = startPos.y + Mathf.Cos(Time.time * hoverSpeed) * hoverMagnitude;
        transform.position = pos;
        
        transform.Rotate(0.0f, Time.time * rotationSpeed, 0.0f);

        // initialy the object rotates around the players starting position
        if(rotate){
            transform.RotateAround(initPlayerPos, Vector3.up, movementSpeed * Time.deltaTime);
        }

        // if 'goToNext' is true, the object moves to the next given waypoint
        if(goToNext){
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(wayPoints[nextwayPoint].x, transform.position.y, wayPoints[nextwayPoint].z), Time.deltaTime * movementSpeed);
            // Once the waypoint has been reached, set 'goToNext' to false and switch to the next waypoint
            if(transform.position.x == wayPoints[nextwayPoint].x && transform.position.z == wayPoints[nextwayPoint].z){
                nextwayPoint++;
                goToNext = false;
            }
        }
    }

    // This function is called, once something enters the box collider of this object
    void OnTriggerEnter(Collider other){
        // the object is no longer supposed to rotate around the players starting position
        rotate = false;
        // If not all waypoints have been reached, go to the next one
        if(nextwayPoint < wayPoints.Length){
            goToNext = true;
        }else{
            interact = true;
        }
    }

    // This function determines what happens if the player interacts with the object
    public override void ObjectInteract()
    {
        _levelLoader.LoadNextLevel();
        
        //SceneManager.LoadScene("Lennart_Test_Scene");
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
