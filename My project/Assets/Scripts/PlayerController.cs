using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float playerHeight;
    private Camera mainCamera;

    [HideInInspector] public UnityEvent<Transform> CarryEvent = new UnityEvent<Transform>();

    [SerializeField] private LayerMask ground = (1 << 17);
    [SerializeField] private Transform orientation;
    
    
    [Header("Movement")]
    [SerializeField] private float movementForce = 20;
    [SerializeField] private float jumpForce = 2;
    [SerializeField] private float maxVelocity = 12;

    [Header("Bitte Ersetzen")]
    [SerializeField] private Transform reflectionOfSelf;

    [SerializeField] private Transform origin;

    

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;

        playerHeight = transform.lossyScale.y;
        
        mainCamera = Camera.main;

        origin.position = transform.position;
        
        //Parent entfernen, damit origin nicht "mitwandert"
        origin.SetParent(null);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -10)
        {
            transform.position = origin.position;
        }
        //Wenn E gedrückt wird, sieh, ob du auf interactable guckst, wenn ja heb es auf
        
        InformCarriedObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }
        processMovement();
        
        
    }


    private bool groundCheck()
    {
        bool isGrounded = groundRaycast(transform.position);

        Vector3 modifiedPosition;
        
        if (!isGrounded)
        {
            modifiedPosition = transform.position;
            modifiedPosition.x += 0.5f;
            groundRaycast(modifiedPosition);
        }
        
        if (!isGrounded)
        {
            modifiedPosition = transform.position;
            modifiedPosition.x -= 0.5f;
            groundRaycast(modifiedPosition);
        }
        
        if (!isGrounded)
        {
            modifiedPosition = transform.position;
            modifiedPosition.z += 0.5f;
            groundRaycast(modifiedPosition);
        }
        
        if (!isGrounded)
        {
            modifiedPosition = transform.position;
            modifiedPosition.z -= 0.5f;
            groundRaycast(modifiedPosition);
        }
        
        return isGrounded;
    }

    private bool groundRaycast(Vector3 originPosition)
    {
        return Physics.Raycast(originPosition, 
            Vector3.down, 
            playerHeight * 0.5f + 0.7f,
            ground);
    }

    private void processMovement()
    {
        Vector3 movementVector = (orientation.right * Input.GetAxis("Horizontal")
                                  + orientation.forward * Input.GetAxis("Vertical")).normalized
                                 * movementForce 
                                 * 100
                                 * Time.deltaTime;


        
        _rigidbody.AddForce(movementVector, ForceMode.Force);
        
        if (Input.GetButtonDown("Jump") && groundCheck())
        {
            
            _rigidbody.AddForce(orientation.up * 
                                jumpForce * 
                                Time.deltaTime *
                                1000,
                                ForceMode.Impulse); 
        }

        Vector2 horizontalVelocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.z);

        if (horizontalVelocity.magnitude > maxVelocity)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxVelocity;
            _rigidbody.velocity = new Vector3(horizontalVelocity.x, _rigidbody.velocity.y, horizontalVelocity.y);
        }

    }

    private void PickUpObject()
    {
        RaycastHit info;
        //Debug.DrawRay(transform.position, mainCamera.transform.forward, Color.green,10000f, true);
        
        
        //Layermask sorgt dafür, dass alle Layer außer 18 ignoriert werden
        bool hit = Physics.Raycast(transform.position, mainCamera.transform.forward, out info, 10, (1 << 18));
        if (hit)
        {
            //Debug.Log($"Raycast hit: {info.transform.gameObject.name}");
            info.transform.GetComponent<PhysicsObject>().ObjectInteract(CarryEvent);
        }
    }

    private void InformCarriedObject()
    {
        reflectionOfSelf.position = transform.position;

        reflectionOfSelf.rotation = mainCamera.transform.rotation;
        
        CarryEvent.Invoke(reflectionOfSelf);
    }
}
