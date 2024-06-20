using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsObject : DynamicObject
{
    private bool activated = false;
    private Rigidbody _rigidbody;

    [SerializeField] private float carryDistance = 2f;
    [SerializeField] private Transform origin;    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (origin != null)
        {
            origin.position = transform.position;
        
            //Parent entfernen, damit origin nicht "mitwandert"
            origin.SetParent(null);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = origin.position;
        } 
    }

    public void ObjectInteract(UnityEvent<Transform> @event)
    {
        if (!activated)
        {
            @event.AddListener(CarryMovement);
            activated = true;
            Debug.Log("Registered");
            _rigidbody.useGravity = false;
        }
        else
        {
            @event.RemoveListener(CarryMovement);
            activated = false;
            Debug.Log("Deregistered");
            _rigidbody.useGravity = true;
        }
    }

    public override void ObjectInteract()
    {
        //base.ObjectInteract();
    }

    private void CarryMovement(Transform positionAndOrientation)
    {
        Transform targetPosition = positionAndOrientation;

        targetPosition.position += positionAndOrientation.forward * carryDistance;

        transform.position = targetPosition.position;
        transform.rotation = targetPosition.rotation;

        //Der Versuch die Bewegung mit Physik zu realisieren funktioniert nicht

        /*
        Vector3 movementVector = targetPosition.position - transform.position;

        movementVector = movementVector.normalized * 10f * movementVector.magnitude;
        
        _rigidbody.AddForce(movementVector);
        
        Vector3 rotationVector = positionAndOrientation.eulerAngles - transform.eulerAngles;
        
        rotationVector = rotationVector.normalized * 10f * rotationVector.magnitude;
        
        _rigidbody.AddTorque(rotationVector);
        */
    }
}
