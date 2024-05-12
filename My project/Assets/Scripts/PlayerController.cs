using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    
    [SerializeField]
    private LayerMask ground;
    private float playerHeight;
    
    [SerializeField] private Transform orientation;
    [Header("Movement")]
    [SerializeField]
    private float movementForce;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxVelocity;

    

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;

        playerHeight = transform.lossyScale.y;
    }

    // Update is called once per frame
    void Update()
    {
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
        return Physics.Raycast(transform.position, 
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
}
