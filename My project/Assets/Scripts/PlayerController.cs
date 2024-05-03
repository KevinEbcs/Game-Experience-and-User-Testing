using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    
    private LayerMask ground;
    private float playerHeight;
    
    [SerializeField] private Transform orientation;
    [Header("Movement")]
    [SerializeField]
    private float movementForce;
    [SerializeField] private float jumpForce;

    

    
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
        bool isGrounded = Physics.Raycast(transform.position, 
            Vector3.down, 
            playerHeight * 0.5f + 0.2f,
            ground);
        
        return isGrounded;
    }

    private void processMovement()
    {
        Vector3 movementVector = (orientation.right * Input.GetAxis("Horizontal")
                                  + orientation.forward * Input.GetAxis("Vertical")).normalized
                                 * movementForce
                                 * Time.deltaTime;
        
        _rigidbody.AddForce(movementVector, ForceMode.Force);
        
        if (Input.GetAxis("Jump")>0 && groundCheck())
        {
            
            _rigidbody.AddForce(orientation.up * 
                                jumpForce * 
                                Time.deltaTime); 
        }

        if (Input.GetAxis("Jump") > 0)
        {
            Debug.Log(playerHeight);    
        }
        
    }
}
