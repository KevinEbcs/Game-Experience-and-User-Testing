using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class MoveablePlatform : MonoBehaviour
{
    public GameObject Path1, Path2;

    private bool direction = true;
    public float speed = (float)0.2;
    private float timer;
    private Rigidbody rb;

    private Vector3 directionVector;
    // Start is called before the first frame update
    void Start()
    {
        timer=0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            directionVector = transform.position - Path1.transform.position;
            //transform.position = Vector3.Lerp(transform.position,Path1.transform.position, timer);
            rb.MovePosition(Vector3.Lerp(transform.position,Path1.transform.position, timer));
            if (directionVector.magnitude < 0.5)
            {
                direction = false;
                timer = 0;
            }
            
            

        }
        else
        {
            directionVector = transform.position - Path2.transform.position;
            //transform.position = Vector3.Lerp(transform.position,Path2.transform.position, timer);
            rb.MovePosition(Vector3.Lerp(transform.position,Path2.transform.position, timer));
            if (directionVector.magnitude < 0.5)
            {
                direction = true;
                timer = 0;
            }
            
        }
        timer += Time.deltaTime * speed;
    }
}
