using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    // old
    [SerializeField] private float movementForce = 20;
    
    // new
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    public float groundDrag;
    public float jumpCooldown;
    public float airMultiplier;
    private bool _readyToJump = true;
    
    [Header("Ground check")]
    public float playerHeight;
    public LayerMask ground;
    private bool _grounded;

    [Header("Keybinds")] 
    public KeyCode jumpKey = KeyCode.Space;
    
    public Transform orientation;

    private float _horizontalInput, _verticalInput;
    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;
    
    private float _moveTmp = 0f;
    
    // old
    private Camera mainCamera;
    private Vector3 origin;
    [HideInInspector] public UnityEvent<Transform> CarryEvent = new UnityEvent<Transform>();
    [Header("Bitte Ersetzen")]
    [SerializeField] private Transform reflectionOfSelf;




    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;

        _moveTmp = moveSpeed;

        // old
        //playerHeight = transform.lossyScale.y;
        mainCamera = Camera.main;
        origin = transform.position;
    }
    
    private void Update()
    {
        // ground check by sending a Ray down, the ray's length is half the player's height
        _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }
        PlayerInput();
        SpeedControl();
        
        // handle drag
        if (_grounded)
        {
            _rigidbody.drag = groundDrag;
            moveSpeed = _moveTmp;
        }
        else
        {
            _rigidbody.drag = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        processMovement();
        
        // If player has fallen out of the level, reset position
        if (transform.position.y < -10)
        {
            transform.position = origin;
        }
        //Wenn E gedrückt wird, sieh, ob du auf interactable guckst, wenn ja heb es auf
        
        InformCarriedObject();
    }

    // not needed
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


    private void PlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        
        // jumping
        if (Input.GetKey(jumpKey) && _readyToJump && _grounded)
        {
            _readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void processMovement()
    {
        // calculate movement direction
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;
        
        // use force mode 'Force' since the movement is applied constantly
        // on ground
        if(_grounded)
            _rigidbody.AddForce(_moveDirection.normalized * (moveSpeed * 10f), ForceMode.Force);
        else if(!_grounded)
            _rigidbody.AddForce(_moveDirection.normalized * (moveSpeed * 10f * airMultiplier), ForceMode.Force);

        /*Vector3 movementVector = (orientation.right * Input.GetAxis("Horizontal")
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
        if (horizontalVelocity.magnitude > moveSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * moveSpeed;
            _rigidbody.velocity = new Vector3(horizontalVelocity.x, _rigidbody.velocity.y, horizontalVelocity.y);
        }*/
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        
        // limit velocity if needed
        // should the max velocity be exceeded, calculate the max speed and apply it
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limiteVal = flatVel.normalized * moveSpeed;
            _rigidbody.velocity = new Vector3(limiteVal.x, _rigidbody.velocity.y, limiteVal.z);
        }
    }

    private void Jump()
    {
        // reset y velocity to make sure the jump height is always the same
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
        // in this case we use 'Impulse' since the jumpForce is only added once
        _rigidbody.AddForce(transform.up * jumpForce,  ForceMode.Impulse);
    }

    private void ResetJump()
    {
        _readyToJump = true;
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
