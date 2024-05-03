using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField]
    private float movementForce;

    [SerializeField] private Transform orientation;

    [SerializeField] private float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = (orientation.right * Input.GetAxis("Horizontal")
            + orientation.forward * Input.GetAxis("Vertical")).normalized
            * movementForce
            * Time.deltaTime;
        
        _rigidbody.AddForce(movementVector, ForceMode.Force);
        
        if (Input.GetAxis("Jump")>0)
        {
           _rigidbody.AddForce(orientation.up * 
                               jumpForce * 
                               Time.deltaTime); 
        }
        
        
    }
}
